﻿namespace AngleSharp.DOM.Css.Properties
{
    using System;

    /// <summary>
    /// Information can be found on MDN:
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/max-width
    /// </summary>
    public sealed class CSSMaxWidthProperty : CSSProperty
    {
        #region Fields

        /// <summary>
        /// The width has no maximum value if _mode == null.
        /// </summary>
        CSSCalcValue _mode;

        #endregion

        #region ctor

        internal CSSMaxWidthProperty()
            : base(PropertyNames.MaxWidth)
        {
            _inherited = false;
            _mode = null;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets if a limit has been specified, otherwise the value is none.
        /// </summary>
        public Boolean IsLimited
        {
            get { return _mode != null; }
        }

        /// <summary>
        /// Gets the specified max-width of the element. A percentage is calculated
        /// with respect to the width of the containing block.
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
            else if (value.Is("none"))
                _mode = null;
            else if (value != CSSValue.Inherit)
                return false;

            return true;
        }

        #endregion
    }
}
