﻿namespace AngleSharp.DOM.Css.Properties
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Information:
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/font-weight
    /// </summary>
    public sealed class CSSFontWeightProperty : CSSProperty
    {
        #region Fields

        static readonly Dictionary<String, FontWeightMode> _weights = new Dictionary<String, FontWeightMode>(StringComparer.OrdinalIgnoreCase);
        FontWeightMode _weight;

        #endregion

        #region ctor

        static CSSFontWeightProperty()
        {
            _weights.Add("normal", new NormalWeightMode());
            _weights.Add("bold", new BoldWeightMode());
            _weights.Add("bolder", new BolderWeightMode());
            _weights.Add("lighter", new LighterWeightMode());
        }

        internal CSSFontWeightProperty()
            : base(PropertyNames.FontWeight)
        {
            _weight = _weights["normal"];
            _inherited = true;
        }

        #endregion

        #region Methods

        protected override Boolean IsValid(CSSValue value)
        {
            FontWeightMode weight;

            if (value is CSSIdentifierValue && _weights.TryGetValue(((CSSIdentifierValue)value).Value, out weight))
                _weight = weight;
            else if (value.ToInteger().HasValue)
                _weight = new NumberWeightMode(value.ToInteger().Value);
            else if (value != CSSValue.Inherit)
                return false;

            return true;
        }

        #endregion

        #region Mode

        abstract class FontWeightMode
        { }

        /// <summary>
        /// Normal font weight. Same as 400.
        /// </summary>
        sealed class NormalWeightMode : FontWeightMode
        {
        }

        /// <summary>
        /// Bold font weight. Same as 700.
        /// </summary>
        sealed class BoldWeightMode : FontWeightMode
        {
        }

        /// <summary>
        /// One font weight lighter than the parent element (among the available weights of the font).
        /// </summary>
        sealed class LighterWeightMode : FontWeightMode
        {
        }

        /// <summary>
        /// One font weight darker than the parent element (among the available weights of the font).
        /// </summary>
        sealed class BolderWeightMode : FontWeightMode
        {
        }

        /// <summary>
        /// Numeric font weights for fonts that provide more than just normal and bold. If the exact
        /// weight given is unavailable, then 600-900 use the closest available darker weight
        /// (or, if there is none, the closest available lighter weight), and 100-500 use the closest
        /// available lighter weight (or, if there is none, the closest available darker weight). This
        /// means that for fonts that provide only normal and bold, 100-500 are normal, and 600-900 are
        /// bold.
        /// </summary>
        sealed class NumberWeightMode : FontWeightMode
        {
            Int32 _weight;

            public NumberWeightMode(Int32 weight)
            {
                _weight = Math.Min(900, Math.Max(100, weight));
            }
        }

        #endregion
    }
}
