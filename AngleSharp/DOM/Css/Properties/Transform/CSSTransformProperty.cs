﻿namespace AngleSharp.DOM.Css.Properties
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// More information available at MDN:
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/transform
    /// </summary>
    public sealed class CSSTransformProperty : CSSProperty
    {
        #region Fields

        List<CSSTransformValue> _transforms;

        #endregion

        #region ctor

        internal CSSTransformProperty()
            : base(PropertyNames.Transform)
        {
            _inherited = false;
            _transforms = new List<CSSTransformValue>();

        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the enumeration over all transformations.
        /// </summary>
        public IEnumerable<CSSTransformValue> Transforms
        {
            get { return _transforms; }
        }

        #endregion

        #region Methods

        protected override Boolean IsValid(CSSValue value)
        {
            if (value.Is("none"))
                _transforms.Clear();
            else if (value is CSSTransformValue)
            {
                _transforms.Clear();
                _transforms.Add((CSSTransformValue)value);
            }
            else if (value is CSSValueList)
            {
                var list = (CSSValueList)value;
                var transforms = new CSSTransformValue[list.Length];

                for (int i = 0; i < transforms.Length; i++)
                {
                    transforms[i] = list[i] as CSSTransformValue;

                    if (transforms[i] == null)
                        return false;
                }

                _transforms.Clear();
                _transforms.AddRange(transforms);
            }
            else if (value != CSSValue.Inherit)
                return false;

            return true;
        }

        #endregion
    }
}
