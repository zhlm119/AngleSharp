﻿namespace AngleSharp.DOM.Css.Properties
{
    using System;

    /// <summary>
    /// Information can be found on MDN:
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/min-width
    /// </summary>
    public sealed class CSSMinWidthProperty : CSSProperty
    {
        #region Fields

        CSSCalcValue _mode;

        #endregion

        #region ctor

        internal CSSMinWidthProperty()
            : base(PropertyNames.MinWidth)
        {
            _inherited = false;
            _mode = CSSCalcValue.Zero;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the minimum height of the element.
        /// </summary>
        public CSSCalcValue Limit
        {
            get { return _mode; }
        }

        #endregion

        #region Methods

        protected override Boolean IsValid(CSSValue value)
        {
            var calc = value.AsCalc();

            if (calc != null)
                _mode = calc;
            else if (value != CSSValue.Inherit)
                return false;

            return true;
        }

        #endregion
    }
}
