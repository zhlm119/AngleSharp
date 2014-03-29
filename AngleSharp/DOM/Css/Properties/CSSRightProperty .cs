﻿namespace AngleSharp.DOM.Css
{
    using System;

    /// <summary>
    /// Information can be found on MDN:
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/right
    /// </summary>
    sealed class CSSRightProperty : CSSCoordinateProperty
    {
        #region ctor

        public CSSRightProperty()
            : base(PropertyNames.RIGHT)
        {
        }

        #endregion
    }
}