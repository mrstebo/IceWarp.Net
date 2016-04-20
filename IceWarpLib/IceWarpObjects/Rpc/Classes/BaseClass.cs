﻿using System.Xml;

namespace IceWarpObjects.Rpc.Classes
{
    public abstract class BaseClass
    {
        /// <summary>
        /// Returns the name of the class.
        /// </summary>
        public string ClassName { get { return this.GetType().Name.ToLower(); } }

        /// <summary>
        /// Empty Constructor
        /// </summary>
        protected BaseClass() { }
        
        /// <summary>
        /// Creates a new instance from an XML node. See <see cref="XmlNode"/> for more information.
        /// </summary>
        /// <param name="node">The Xml node. See <see cref="XmlNode"/> for more information.</param>
        protected BaseClass(XmlNode node) { }

        /// <summary>
        /// Generates the XML for the class.
        /// </summary>
        /// <param name="doc">The XML document See <see cref="XmlDocument"/> for more information.</param>
        /// <param name="name">The elements name.</param>
        /// <returns>The new XML element. See <see cref="XmlElement"/> for more information.</returns>
        public abstract XmlElement BuildXmlElement(XmlDocument doc, string name);
    }
}
