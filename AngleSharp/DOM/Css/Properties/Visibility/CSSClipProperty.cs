﻿namespace AngleSharp.DOM.Css.Properties
{
    using System;
    
    /// <summary>
    /// More information can be found:
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/clip
    /// </summary>
    public sealed class CSSClipProperty : CSSProperty
    {
        #region Fields

        CSSShapeValue _shape;

        #endregion

        #region ctor

        internal CSSClipProperty()
            : base(PropertyNames.Clip)
        {
            _shape = null;
            _inherited = false;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the shape of the selected clipping region.
        /// If this value is null, then the clipping is
        /// determined automatically.
        /// </summary>
        public CSSShapeValue Clip
        {
            get { return _shape; }
        }

        #endregion

        #region Methods

        protected override Boolean IsValid(CSSValue value)
        {
            var shape = value as CSSShapeValue;

            if (shape != null)
                _shape = shape;
            else if (value.Is("auto"))
                _shape = null;
            else if (value != CSSValue.Inherit)
                return false;

            return true;
        }

        #endregion
    }
}
