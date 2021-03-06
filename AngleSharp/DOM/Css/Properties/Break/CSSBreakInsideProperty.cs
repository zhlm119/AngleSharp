﻿namespace AngleSharp.DOM.Css.Properties
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Information can be found on MDN:
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/break-inside
    /// or even better
    /// http://dev.w3.org/csswg/css-break/#break-inside
    /// </summary>
    public sealed class CSSBreakInsideProperty : CSSProperty
    {
        #region Fields

        static readonly Dictionary<String, BreakMode> modes = new Dictionary<String, BreakMode>(StringComparer.OrdinalIgnoreCase);
        BreakMode _mode;

        #endregion

        #region ctor

        static CSSBreakInsideProperty()
        {
            modes.Add("auto", BreakMode.Auto);
            modes.Add("avoid", BreakMode.Avoid);
            modes.Add("avoid-page", BreakMode.AvoidPage);
            modes.Add("avoid-column", BreakMode.AvoidColumn);
            modes.Add("avoid-region", BreakMode.AvoidRegion);
        }

        internal CSSBreakInsideProperty()
            : base(PropertyNames.BreakInside)
        {
            _mode = BreakMode.Auto;
            _inherited = false;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the selected break mode.
        /// </summary>
        public BreakMode Mode
        {
            get { return _mode; }
        }

        #endregion

        #region Methods

        protected override Boolean IsValid(CSSValue value)
        {
            BreakMode mode;

            if (value is CSSIdentifierValue && modes.TryGetValue(((CSSIdentifierValue)value).Value, out mode))
                _mode = mode;
            else if (value != CSSValue.Inherit)
                return false;

            return true;
        }

        #endregion
    }
}
