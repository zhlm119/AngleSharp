﻿namespace AngleSharp.DOM.Html
{
    using System;

    /// <summary>
    /// Represents the HTML html element.
    /// </summary>
    [DOM("HTMLHtmlElement")]
    public sealed class HTMLHtmlElement : HTMLElement, IScopeElement, ITableScopeElement, IImplClosed
    {
        #region ctor

        /// <summary>
        /// Creates a new HTML html tag.
        /// </summary>
        internal HTMLHtmlElement()
        {
            _name = Tags.Html;
        }

        #endregion

        #region Internal properties

        /// <summary>
        /// Gets if the node is in the special category.
        /// </summary>
        protected internal override Boolean IsSpecial
        {
            get { return true; }
        }

        #endregion
    }
}
