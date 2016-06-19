using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace XW.Configuration
{
	[PublicAPI]
	public class XmlConfigurationProvider : IKeyedConfigurationProvider
	{
		private readonly IKeyedDomainStorage mStorage;
		private readonly string mContainerKey;

		private static readonly XName mRootElementName = XName.Get(@"configuration");
		private static readonly XName mContainerElementName = XName.Get(@"appSettings");
		private static readonly XName mItemElementName = XName.Get(@"add");
		private static readonly XName mKeyAttributeName = XName.Get(@"key");
		private static readonly XName mValueAttributeName = XName.Get(@"value");

		public XmlConfigurationProvider([NotNull] IKeyedDomainStorage storage, [NotNull] string containerKey)
		{
			if (storage == null)
			{
				throw new ArgumentNullException(nameof(storage));
			}

			if (string.IsNullOrWhiteSpace(containerKey))
			{
				throw new ArgumentNullException(nameof(containerKey));
			}

			mStorage = storage;
			mContainerKey = containerKey;

			if (!mStorage.HasContainer(containerKey))
			{
				CreateXml();
			}
		}

		public string ReadValue(string key)
		{
			var element = GetItemElement(key);

			return element?.Attribute(mValueAttributeName)?.Value;
		}
		public void WriteValue(string key, string value)
		{
			XDocument document;

			var element = GetItemElement(key, out document);

			try
			{
				if (element == null)
				{
					var container = GetContainerElement(out document);
					container.Add(new XElement(mItemElementName,
						new XAttribute(mKeyAttributeName, key),
						new XAttribute(mValueAttributeName, value ?? string.Empty)));
				}
				else
				{
					var attribute = element.Attribute(mValueAttributeName);
					if (attribute == null)
					{
						element.Add(new XAttribute(mValueAttributeName, value ?? string.Empty));
					}
					else
					{
						attribute.Value = value ?? string.Empty;
					}
				}

				SaveDocument(document);
			}
			catch (XmlException xmlException)
			{
				var formattedMessage = string.Format(
					Messages.ErrFailedToWriteXmlConfiguration,
					mContainerKey,
					xmlException.Message);

				throw new FormatException(formattedMessage, xmlException);
			}
		}
		public void SetDefault(string key, string defaultValue)
		{
			if (!HasValue(key))
			{
				WriteValue(key, defaultValue);
			}
		}

		public bool HasValue(string key)
		{
			var element = GetItemElement(key);

			return element != null;
		}
		public bool IsReadOnly => false;

		public IEnumerable<string> GetKeys()
		{
			var container = GetContainerElement();
			var nodes = container.Elements(mItemElementName);

			return
				from node in nodes
				let keyAttribute = node.Attribute(mKeyAttributeName)
				where keyAttribute != null
				select keyAttribute.Value;
		}

		private void CreateXml()
		{
			var document = new XDocument(
				new XDeclaration("1.0", "utf-8", ""),
				new XElement(mRootElementName,
					new XElement(mContainerElementName)));

			SaveDocument(document);
		}

		private XElement GetItemElement(string key)
		{
			XDocument document;
			return GetItemElement(key, out document);
		}
		private XElement GetItemElement(string key, out XDocument document)
		{
			if (string.IsNullOrWhiteSpace(key))
			{
				throw new ArgumentNullException(nameof(key));
			}

			var container = GetContainerElement(out document);
			var nodes = container.Elements(mItemElementName);
			var result = nodes.FirstOrDefault(x => x.Attribute(mKeyAttributeName)?.Value == key);

			return result;
		}

		private XElement GetContainerElement()
		{
			XDocument document;
			return GetContainerElement(out document);
		}
		private XElement GetContainerElement(out XDocument document)
		{
			try
			{
				document = LoadDocument();

				var root = document.Element(mRootElementName);
				if (root == null)
				{
					var formattedMessage = string.Format(
						Messages.ErrFailedToReadXmlConfiguration, mContainerKey,
						Messages.ErrXmlConfigurationHasMismatchingRootNode);

					throw new FormatException(formattedMessage);
				}

				var container = root.Element(mContainerElementName);
				if (container == null)
				{
					var formattedMessage = string.Format(
						Messages.ErrFailedToReadXmlConfiguration, mContainerKey,
						Messages.ErrXmlConfigurationHasMismatchingContainerNode);

					throw new FormatException(formattedMessage);
				}

				return container;
			}
			catch (XmlException xmlException)
			{
				var formattedMessage = string.Format(
					Messages.ErrFailedToReadXmlConfiguration,
					mContainerKey,
					xmlException.Message);

				throw new FormatException(formattedMessage, xmlException);
			}
		}

		private XDocument LoadDocument()
		{
			using (var stream = mStorage.ReadContainer(mContainerKey))
			{
				return XDocument.Load(stream, LoadOptions.None);
			}
		}
		private void SaveDocument(XDocument document)
		{
			using (var stream = mStorage.WriteContainer(mContainerKey))
			{
				document.Save(stream, SaveOptions.None);
			}
		}
	}
}