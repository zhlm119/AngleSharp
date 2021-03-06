﻿namespace AngleSharp.DOM.Css.Properties
{
    using System;

    /// <summary>
    /// Basis for all elementary border-radius properties.
    /// </summary>
    public class CSSBorderRadiusPartProperty : CSSProperty
    {
        #region Fields

        CSSCalcValue _h;
        CSSCalcValue _v;

        #endregion

        #region ctor

        protected CSSBorderRadiusPartProperty(String name)
            : base(name)
        {
            _inherited = false;
            _h = CSSCalcValue.Zero;
            _v = CSSCalcValue.Zero;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the horizontal radius of the ellipse.
        /// </summary>
        public CSSCalcValue HorizontalRadius
        {
            get { return _h; }
        }

        /// <summary>
        /// Gets the vertical radius of the ellipse.
        /// </summary>
        public CSSCalcValue VerticalRadius
        {
            get { return _v; }
        }

        #endregion

        #region Methods

        protected override Boolean IsValid(CSSValue value)
        {
            var list = value as CSSValueList;
            var v1 = value;
            var v2 = value;

            if (list != null)
            {
                if (list.Length != 2)
                    return false;

                v1 = list[0];
                v2 = list[1];
            }

            var c1 = v1.AsCalc();
            var c2 = v2.AsCalc();

            if (c1 != null && c2 != null)
            {
                _h = c1;
                _v = c2;
            }
            else if (value != CSSValue.Inherit)
                return false;

            return true;
        }

        #endregion
    }
}
