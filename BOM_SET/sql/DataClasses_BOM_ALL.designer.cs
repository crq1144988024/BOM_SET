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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Database1.mdf")]
	public partial class DataClasses_BOM_ALLDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region 可扩展性方法定义
    partial void OnCreated();
    partial void InsertBOM_ALL(BOM_ALL instance);
    partial void UpdateBOM_ALL(BOM_ALL instance);
    partial void DeleteBOM_ALL(BOM_ALL instance);
    #endregion
		
		public DataClasses_BOM_ALLDataContext() : 
				base(global::BOM_SET.Properties.Settings.Default.Database1_mdfConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses_BOM_ALLDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses_BOM_ALLDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses_BOM_ALLDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses_BOM_ALLDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<BOM_ALL> BOM_ALL
		{
			get
			{
				return this.GetTable<BOM_ALL>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.BOM_ALL")]
	public partial class BOM_ALL : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private System.Nullable<int> _项目ID;
		
		private string _项目代号;
		
		private System.Nullable<int> _物料ID;
		
		private System.Nullable<int> _数量;
		
		private string _备注;
		
		private string _审核状态;
		
		private string _审核意见;
		
		private string _是否采购;
		
		private string _采购状态;
		
		private System.Nullable<int> _已采购数量;
		
		private string _提交审核;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void On项目IDChanging(System.Nullable<int> value);
    partial void On项目IDChanged();
    partial void On项目代号Changing(string value);
    partial void On项目代号Changed();
    partial void On物料IDChanging(System.Nullable<int> value);
    partial void On物料IDChanged();
    partial void On数量Changing(System.Nullable<int> value);
    partial void On数量Changed();
    partial void On备注Changing(string value);
    partial void On备注Changed();
    partial void On审核状态Changing(string value);
    partial void On审核状态Changed();
    partial void On审核意见Changing(string value);
    partial void On审核意见Changed();
    partial void On是否采购Changing(string value);
    partial void On是否采购Changed();
    partial void On采购状态Changing(string value);
    partial void On采购状态Changed();
    partial void On已采购数量Changing(System.Nullable<int> value);
    partial void On已采购数量Changed();
    partial void On提交审核Changing(string value);
    partial void On提交审核Changed();
    #endregion
		
		public BOM_ALL()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_项目ID", DbType="Int")]
		public System.Nullable<int> 项目ID
		{
			get
			{
				return this._项目ID;
			}
			set
			{
				if ((this._项目ID != value))
				{
					this.On项目IDChanging(value);
					this.SendPropertyChanging();
					this._项目ID = value;
					this.SendPropertyChanged("项目ID");
					this.On项目IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_项目代号", DbType="NChar(10)")]
		public string 项目代号
		{
			get
			{
				return this._项目代号;
			}
			set
			{
				if ((this._项目代号 != value))
				{
					this.On项目代号Changing(value);
					this.SendPropertyChanging();
					this._项目代号 = value;
					this.SendPropertyChanged("项目代号");
					this.On项目代号Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_物料ID", DbType="Int")]
		public System.Nullable<int> 物料ID
		{
			get
			{
				return this._物料ID;
			}
			set
			{
				if ((this._物料ID != value))
				{
					this.On物料IDChanging(value);
					this.SendPropertyChanging();
					this._物料ID = value;
					this.SendPropertyChanged("物料ID");
					this.On物料IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_数量", DbType="Int")]
		public System.Nullable<int> 数量
		{
			get
			{
				return this._数量;
			}
			set
			{
				if ((this._数量 != value))
				{
					this.On数量Changing(value);
					this.SendPropertyChanging();
					this._数量 = value;
					this.SendPropertyChanged("数量");
					this.On数量Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_备注", DbType="NVarChar(255)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_审核状态", DbType="NChar(10)")]
		public string 审核状态
		{
			get
			{
				return this._审核状态;
			}
			set
			{
				if ((this._审核状态 != value))
				{
					this.On审核状态Changing(value);
					this.SendPropertyChanging();
					this._审核状态 = value;
					this.SendPropertyChanged("审核状态");
					this.On审核状态Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_审核意见", DbType="NVarChar(255)")]
		public string 审核意见
		{
			get
			{
				return this._审核意见;
			}
			set
			{
				if ((this._审核意见 != value))
				{
					this.On审核意见Changing(value);
					this.SendPropertyChanging();
					this._审核意见 = value;
					this.SendPropertyChanged("审核意见");
					this.On审核意见Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_是否采购", DbType="NChar(10)")]
		public string 是否采购
		{
			get
			{
				return this._是否采购;
			}
			set
			{
				if ((this._是否采购 != value))
				{
					this.On是否采购Changing(value);
					this.SendPropertyChanging();
					this._是否采购 = value;
					this.SendPropertyChanged("是否采购");
					this.On是否采购Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_采购状态", DbType="NChar(10)")]
		public string 采购状态
		{
			get
			{
				return this._采购状态;
			}
			set
			{
				if ((this._采购状态 != value))
				{
					this.On采购状态Changing(value);
					this.SendPropertyChanging();
					this._采购状态 = value;
					this.SendPropertyChanged("采购状态");
					this.On采购状态Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_已采购数量", DbType="Int")]
		public System.Nullable<int> 已采购数量
		{
			get
			{
				return this._已采购数量;
			}
			set
			{
				if ((this._已采购数量 != value))
				{
					this.On已采购数量Changing(value);
					this.SendPropertyChanging();
					this._已采购数量 = value;
					this.SendPropertyChanged("已采购数量");
					this.On已采购数量Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_提交审核", DbType="NChar(10)")]
		public string 提交审核
		{
			get
			{
				return this._提交审核;
			}
			set
			{
				if ((this._提交审核 != value))
				{
					this.On提交审核Changing(value);
					this.SendPropertyChanging();
					this._提交审核 = value;
					this.SendPropertyChanged("提交审核");
					this.On提交审核Changed();
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