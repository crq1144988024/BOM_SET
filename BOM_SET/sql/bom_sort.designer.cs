﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace BOM_SET.sql
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Database1")]
	public partial class bom_sortDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region 可扩展性方法定义
    partial void OnCreated();
    partial void InsertTable_BOM_struct_sort_(Table_BOM_struct_sort_ instance);
    partial void UpdateTable_BOM_struct_sort_(Table_BOM_struct_sort_ instance);
    partial void DeleteTable_BOM_struct_sort_(Table_BOM_struct_sort_ instance);
    #endregion
		
		public bom_sortDataContext() : 
				base(global::BOM_SET.Properties.Settings.Default.Database1ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public bom_sortDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public bom_sortDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public bom_sortDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public bom_sortDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Table_BOM_struct_sort_> Table_BOM_struct_sort_
		{
			get
			{
				return this.GetTable<Table_BOM_struct_sort_>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.[Table_BOM_struct_sort ]")]
	public partial class Table_BOM_struct_sort_ : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private int _备用ID;
		
		private string _一级菜单;
		
		private string _二级菜单;
		
		private string _三级菜单;
		
		private System.Nullable<int> _main_BOMID;
		
		private string _名称;
		
		private string _备注;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void On备用IDChanging(int value);
    partial void On备用IDChanged();
    partial void On一级菜单Changing(string value);
    partial void On一级菜单Changed();
    partial void On二级菜单Changing(string value);
    partial void On二级菜单Changed();
    partial void On三级菜单Changing(string value);
    partial void On三级菜单Changed();
    partial void Onmain_BOMIDChanging(System.Nullable<int> value);
    partial void Onmain_BOMIDChanged();
    partial void On名称Changing(string value);
    partial void On名称Changed();
    partial void On备注Changing(string value);
    partial void On备注Changed();
    #endregion
		
		public Table_BOM_struct_sort_()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_备用ID", DbType="Int NOT NULL")]
		public int 备用ID
		{
			get
			{
				return this._备用ID;
			}
			set
			{
				if ((this._备用ID != value))
				{
					this.On备用IDChanging(value);
					this.SendPropertyChanging();
					this._备用ID = value;
					this.SendPropertyChanged("备用ID");
					this.On备用IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_一级菜单", DbType="NChar(10)")]
		public string 一级菜单
		{
			get
			{
				return this._一级菜单;
			}
			set
			{
				if ((this._一级菜单 != value))
				{
					this.On一级菜单Changing(value);
					this.SendPropertyChanging();
					this._一级菜单 = value;
					this.SendPropertyChanged("一级菜单");
					this.On一级菜单Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_二级菜单", DbType="NChar(10)")]
		public string 二级菜单
		{
			get
			{
				return this._二级菜单;
			}
			set
			{
				if ((this._二级菜单 != value))
				{
					this.On二级菜单Changing(value);
					this.SendPropertyChanging();
					this._二级菜单 = value;
					this.SendPropertyChanged("二级菜单");
					this.On二级菜单Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_三级菜单", DbType="NChar(10)")]
		public string 三级菜单
		{
			get
			{
				return this._三级菜单;
			}
			set
			{
				if ((this._三级菜单 != value))
				{
					this.On三级菜单Changing(value);
					this.SendPropertyChanging();
					this._三级菜单 = value;
					this.SendPropertyChanged("三级菜单");
					this.On三级菜单Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_main_BOMID", DbType="Int")]
		public System.Nullable<int> main_BOMID
		{
			get
			{
				return this._main_BOMID;
			}
			set
			{
				if ((this._main_BOMID != value))
				{
					this.Onmain_BOMIDChanging(value);
					this.SendPropertyChanging();
					this._main_BOMID = value;
					this.SendPropertyChanged("main_BOMID");
					this.Onmain_BOMIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_名称", DbType="NChar(255)")]
		public string 名称
		{
			get
			{
				return this._名称;
			}
			set
			{
				if ((this._名称 != value))
				{
					this.On名称Changing(value);
					this.SendPropertyChanging();
					this._名称 = value;
					this.SendPropertyChanged("名称");
					this.On名称Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_备注", DbType="NChar(255)")]
		public string 备注
		{
			get
			{
				return this._备注;
			}
			set
			{
				if ((this._备注 != value))
				{
					this.On备注Changing(value);
					this.SendPropertyChanging();
					this._备注 = value;
					this.SendPropertyChanged("备注");
					this.On备注Changed();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
