using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;
using XyrusWorx.Structures;

namespace XyrusWorx.Gaming.AnnoCompanion.ObjectModel
{
	[DebuggerDisplay("{OutputGood.DisplayName}")]
	class ProductionChain : IndexedObject
	{
		private ProductionChainComponent[] mComponents;
		private ObjectDependencyGraph<Good> mGraph;
		private Good mOutput;

		public ProductionChain()
		{
			mGraph = new ObjectDependencyGraph<Good>();
		}

		[JsonIgnore]
		public Good OutputGood => mOutput;

		[JsonRequired]
		public ProductionChainComponent[] Components
		{
			get { return mComponents; }
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
					graph.Register(input.Good);
				}

				graph.Register(component.Building.Output.Good);

				var output = graph.Element(component.Building.Output.Good);
				foreach (var input in component.Building.Input)
				{
					output.DependsOn(input.Good);
				}
			}

			mGraph = graph;

			try
			{
				mOutput = graph.GetPartitionsByDependencyDepth().Last().Single();
			}
			catch (Exception exception)
			{
				var outputs = string.Join(", ", graph.GetPartitionsByDependencyDepth().Last().Select(x => x.Key));

				throw new InvalidDataException($"A production chain contains multiple outputs: {outputs}", exception);
			}
		}
	}
}