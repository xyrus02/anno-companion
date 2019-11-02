using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;
using XyrusWorx.Gaming.AnnoCompanion.Data;
using XyrusWorx.Structures;

namespace XyrusWorx.Gaming.AnnoCompanion.Models
{
	[PublicAPI]
	[DebuggerDisplay("{OutputGood.DisplayName,nq}")]
	public class ProductionChain : Persistable
	{
		private ProductionChainComponent[] mComponents;
		private ObjectDependencyGraph<Good> mGraph;
		private ProductionBuilding mOutputBuilding;

		public ProductionChain()
		{
			mGraph = new ObjectDependencyGraph<Good>();
		}

		[JsonIgnore]
		public Good OutputGood => OutputBuilding?.Output.Good;

		[JsonIgnore]
		public ProductionBuilding OutputBuilding => mOutputBuilding;

		[JsonProperty(Required = Required.Always, Order = 2)]
		public ProductionChainComponent[] Components
		{
			get => mComponents;
			set
			{
				if (Equals(Components, value))
				{
					return;
				}

				mComponents = value;
				CreateProductionChainLayout();
			}
		}

		[NotNull, JsonIgnore]
		public ObjectDependencyGraph<Good> DependencyStructure => mGraph;

		private void CreateProductionChainLayout()
		{
			var graph = new ObjectDependencyGraph<Good>();

			foreach (var component in Components)
			{
				foreach (var input in component.Building.Input)
				{
					var good = input.Input as Good;
					if (good == null)
					{
						continue;
					}

					graph.Register(good);
				}

				graph.Register(component.Building.Output.Good);

				var output = graph.Element(component.Building.Output.Good);
				foreach (var input in component.Building.Input)
				{
					var good = input.Input as Good;
					if (good == null)
					{
						continue;
					}

					output.DependsOn(good);
				}
			}

			mGraph = graph;

			Good outputGood;

			try
			{
				outputGood = graph.GetPartitionsByDependencyDepth().Last().Single();
			}
			catch (Exception exception)
			{
				var outputs = string.Join(", ", graph.GetPartitionsByDependencyDepth().Last().Select(x => x.Key));

				throw new InvalidDataException($"A production chain contains multiple outputs: {outputs}", exception);
			}

			try
			{
				mOutputBuilding = Components.Single(x => x.Building.Output.Good == outputGood).Building;
			}
			catch (Exception exception)
			{
				throw new InvalidDataException($"Can't find production building for output good: {outputGood.DisplayName}", exception);
			}
		}
	}
}