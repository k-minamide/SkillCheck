using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using SkillCheck.Base;
using SkillCheck.ViewModel.Data;
using SkillCheck.Utility.DB;

using System.Configuration;
using System.Data.SQLite;
using SkillCheck.Base.Data;
using SkillCheck.Model;
using SkillCheck.Utility.Extention;

namespace SkillCheck.ViewModel
{
    public class MainViewModel : NotifyPropertyChangedBase
    {
        public MainViewModel()
        {
            this.PlaceDataTable = DataAccesser.GetPlaceData();
        }

        private PlaceDataTable placeDataTable = new PlaceDataTable();
        public PlaceDataTable PlaceDataTable
        {
            get { return this.placeDataTable; }
            set { base.SetValue(value, ref this.placeDataTable); }
        }

        private PlaceDataRow selectedPlaceDataRow;
        public PlaceDataRow SelectedPlaceDataRow
        {
            get { return this.selectedPlaceDataRow; }
            set
            {
                base.SetValue(value, ref this.selectedPlaceDataRow);
                if (this.selectedPlaceDataRow.IsNull())
                { this.BookshelfDataTable = null; }
                else
                { this.BookshelfDataTable = DataAccesser.GetBookshelfData(this.selectedPlaceDataRow.ID); }
            }
        }

        private BookshelfDataTable bookshelfDataTable = new BookshelfDataTable();
        public BookshelfDataTable BookshelfDataTable
        {
            get { return this.bookshelfDataTable; }
            set
            { base.SetValue(value, ref this.bookshelfDataTable); }
        }

        private BookshelfDataRow selectedBookshelfDataRow;
        public BookshelfDataRow SelectedBookshelfDataRow
        {
            get { return this.selectedBookshelfDataRow; }
            set
            {
                base.SetValue(value, ref this.selectedBookshelfDataRow);
                if (this.selectedBookshelfDataRow.IsNull())
                { this.ShelfDataTable = null; }
                else
                { this.ShelfDataTable = DataAccesser.GetShelfData(this.selectedBookshelfDataRow.PlaceID, this.selectedBookshelfDataRow.ID); }
            }
        }

        private ShelfDataTable shelfDataTable = new ShelfDataTable();
        public ShelfDataTable ShelfDataTable
        {
            get { return this.shelfDataTable; }
            set { base.SetValue(value, ref this.shelfDataTable); }
        }

        private ShelfDataRow selectedShelfDataRow;
        public ShelfDataRow SelectedShelfDataRow
        {
            get { return this.selectedShelfDataRow; }
            set
            {
                base.SetValue(value, ref this.selectedShelfDataRow);
                if (this.selectedShelfDataRow.IsNull())
                {
                    this.BookDataTable = null;
                    this.CategoryDataTable = null;
                }
                else
                {
                    // 本
                    this.BookDataTable = DataAccesser.GetBookData(this.selectedShelfDataRow.PlaceID, this.selectedShelfDataRow.BookshelfID, this.selectedShelfDataRow.ID);

                    // カテゴリ
                    this.CategoryDataTable = DataAccesser.GetCategoryData(this.selectedShelfDataRow.PlaceID, this.selectedShelfDataRow.BookshelfID, this.selectedShelfDataRow.ID);
                }
            }
        }

        private TableBase<CategoryDataRow> categoryDataTable = new CategoryDataTable();
        public TableBase<CategoryDataRow> CategoryDataTable
        {
            get { return this.categoryDataTable; }
            set
            { base.SetValue(value, ref this.categoryDataTable); }
        }

        private CategoryDataRow selectedCategoryDataRow;
        public CategoryDataRow SelectedCategoryDataRow
        {
            get { return this.selectedCategoryDataRow; }
            set
            {
                base.SetValue(value, ref this.selectedCategoryDataRow);
                this.BookDataTable = DataAccesser.GetBookData(this.selectedCategoryDataRow.ID);
            }
        }

        private BookDataTable bookDataTable = new BookDataTable();
        public BookDataTable BookDataTable
        {
            get { return this.bookDataTable; }
            set { base.SetValue(value, ref this.bookDataTable); }
        }

        private BookDataRow selectedBookDataRow;
        public BookDataRow SelectedBookDataRow
        {
            get { return this.selectedBookDataRow; }
            set { base.SetValue(value, ref this.selectedBookDataRow); }
        }
    }
}
