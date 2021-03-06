﻿namespace AngleSharp.DOM.Html
{
    using AngleSharp.DOM.Collections;
    using System;

    /// <summary>
    /// Represents the object for HTML table section (thead / tbody / tfoot) elements.
    /// </summary>
    [DOM("HTMLTableSectionElement")]
    public sealed class HTMLTableSectionElement : HTMLElement, IImplClosed, ITableSectionScopeElement
    {
        #region Fields

        HTMLCollection<HTMLTableRowElement> _rows;

        #endregion

        #region ctor

        internal HTMLTableSectionElement()
        {
            _name = Tags.Tbody;
            _rows = new HTMLCollection<HTMLTableRowElement>(this);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the value of the horizontal alignment attribute.
        /// </summary>
        [DOM("align")]
        public HorizontalAlignment Align
        {
            get { return ToEnum(GetAttribute("align"), HorizontalAlignment.Center); }
            set { SetAttribute("align", value.ToString()); }
        }

        /// <summary>
        /// Gets the assigned table rows.
        /// </summary>
        [DOM("rows")]
        public HTMLCollection<HTMLTableRowElement> Rows
        {
            get { return _rows; }
        }

        /// <summary>
        /// Gets or sets the value of the vertical alignment attribute.
        /// </summary>
        [DOM("vAlign")]
        public VerticalAlignment VAlign
        {
            get { return ToEnum(GetAttribute("valign"), VerticalAlignment.Middle); }
            set { SetAttribute("valign", value.ToString()); }
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

        #region Methods

        /// <summary>
        /// Inserts a row into this section. The new row is inserted immediately before the
        /// current indexth row in this section. If index is -1 or equal to the number of
        /// rows in this section, the new row is appended.
        /// </summary>
        /// <param name="index">The row number where to insert a new row. This index
        /// starts from 0 and is relative only to the rows contained inside this section,
        /// not all the rows in the table.</param>
        /// <returns>The inserted table row.</returns>
        [DOM("insertRow")]
        public HTMLTableRowElement InsertRow(Int32 index)
        {
            var row = Rows[index];
            var newRow = OwnerDocument.CreateElement(Tags.Tr) as HTMLTableRowElement;

            if (row != null)
                InsertBefore(newRow, row);
            else
                AppendChild(newRow);

            return newRow;
        }

        /// <summary>
        /// Deletes a row from this section.
        /// </summary>
        /// <param name="index">The index of the row to be deleted, or -1 to delete the last
        /// row. This index starts from 0 and is relative only to the rows contained inside
        /// this section, not all the rows in the table.</param>
        /// <returns>The current table.</returns>
        [DOM("deleteRow")]
        public HTMLTableSectionElement DeleteRow(Int32 index)
        {
            var row = Rows[index];

            if (row != null)
                row.Remove();

            return this;
        }

        #endregion
    }
}
