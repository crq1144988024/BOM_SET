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
	public partial class DataClasses_ADD_BOM_TEMPDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region 可扩展性方法定义
    partial void OnCreated();
    partial void InsertTable_bom_all_add_temp(Table_bom_all_add_temp instance);
    partial void UpdateTable_bom_all_add_temp(Table_bom_all_add_temp instance);
    partial void DeleteTable_bom_all_add_temp(Table_bom_all_add_temp instance);
    #endregion
		
		public DataClasses_ADD_BOM_TEMPDataContext() : 
				base(global::BOM_SET.Properties.Settings.Default.Database1_mdfConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses_ADD_BOM_TEMPDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses_ADD_BOM_TEMPDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses_ADD_BOM_TEMPDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses_ADD_BOM_TEMPDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Table_bom_all_add_temp> Table_bom_all_add_temp
		{
			get
			{
				return this.GetTable<Table_bom_all_add_temp>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Table_bom_all_add_temp")]
	public partial class Table_bom_all_add_temp : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _类别;
		
		private string _物料ID;
		
		private string _代码;
		
		private string _名称;
		
		private string _全名;
		
		private string _规格型号;
		
		private string _新增人;
		
		private string _审核人;
		
		private string _附件;
		
		private string _图片;
		
		private System.Nullable<int> _价格;
		
		private string _技术参数;
		
		private string _品牌;
		
		private string _备注;
		
		private string _资料路径;
		
		private string _是否提交;
		
		private string _是否审核;
		
		private string _审核意见;
		
		private string _审核日期;
		
		private string _新增日期;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void On类别Changing(string value);
    partial void On类别Changed();
    partial void On物料IDChanging(string value);
    partial void On物料IDChanged();
    partial void On代码Changing(string value);
    partial void On代码Changed();
    partial void On名称Changing(string value);
    partial void On名称Changed();
    partial void On全名Changing(string value);
    partial void On全名Changed();
    partial void On规格型号Changing(string value);
    partial void On规格型号Changed();
    partial void On新增人Changing(string value);
    partial void On新增人Changed();
    partial void On审核人Changing(string value);
    partial void On审核人Changed();
    partial void On附件Changing(string value);
    partial void On附件Changed();
    partial void On图片Changing(string value);
    partial void On图片Changed();
    partial void On价格Changing(System.Nullable<int> value);
    partial void On价格Changed();
    partial void On技术参数Changing(string value);
    partial void On技术参数Changed();
    partial void On品牌Changing(string value);
    partial void On品牌Changed();
    partial void On备注Changing(string value);
    partial void On备注Changed();
    partial void On资料路径Changing(string value);
    partial void On资料路径Changed();
    partial void On是否提交Changing(string value);
    partial void On是否提交Changed();
    partial void On是否审核Changing(string value);
    partial void On是否审核Changed();
    partial void On审核意见Changing(string value);
    partial void On审核意见Changed();
    partial void On审核日期Changing(string value);
    partial void On审核日期Changed();
    partial void On新增日期Changing(string value);
    partial void On新增日期Changed();
    #endregion
		
		public Table_bom_all_add_temp()
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_类别", DbType="NVarChar(255)")]
		public string 类别
		{
			get
			{
				return this._类别;
			}
			set
			{
				if ((this._类别 != value))
				{
					this.On类别Changing(value);
					this.SendPropertyChanging();
					this._类别 = value;
					this.SendPropertyChanged("类别");
					this.On类别Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_物料ID", DbType="NVarChar(255)")]
		public string 物料ID
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_代码", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string 代码
		{
			get
			{
				return this._代码;
			}
			set
			{
				if ((this._代码 != value))
				{
					this.On代码Changing(value);
					this.SendPropertyChanging();
					this._代码 = value;
					this.SendPropertyChanged("代码");
					this.On代码Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_名称", DbType="NVarChar(255)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_全名", DbType="NVarChar(255)")]
		public string 全名
		{
			get
			{
				return this._全名;
			}
			set
			{
				if ((this._全名 != value))
				{
					this.On全名Changing(value);
					this.SendPropertyChanging();
					this._全名 = value;
					this.SendPropertyChanged("全名");
					this.On全名Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_规格型号", DbType="NVarChar(255)")]
		public string 规格型号
		{
			get
			{
				return this._规格型号;
			}
			set
			{
				if ((this._规格型号 != value))
				{
					this.On规格型号Changing(value);
					this.SendPropertyChanging();
					this._规格型号 = value;
					this.SendPropertyChanged("规格型号");
					this.On规格型号Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_新增人", DbType="NChar(10)")]
		public string 新增人
		{
			get
			{
				return this._新增人;
			}
			set
			{
				if ((this._新增人 != value))
				{
					this.On新增人Changing(value);
					this.SendPropertyChanging();
					this._新增人 = value;
					this.SendPropertyChanged("新增人");
					this.On新增人Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_审核人", DbType="NVarChar(255)")]
		public string 审核人
		{
			get
			{
				return this._审核人;
			}
			set
			{
				if ((this._审核人 != value))
				{
					this.On审核人Changing(value);
					this.SendPropertyChanging();
					this._审核人 = value;
					this.SendPropertyChanged("审核人");
					this.On审核人Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_附件", DbType="NVarChar(255)")]
		public string 附件
		{
			get
			{
				return this._附件;
			}
			set
			{
				if ((this._附件 != value))
				{
					this.On附件Changing(value);
					this.SendPropertyChanging();
					this._附件 = value;
					this.SendPropertyChanged("附件");
					this.On附件Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_图片", DbType="NVarChar(255)")]
		public string 图片
		{
			get
			{
				return this._图片;
			}
			set
			{
				if ((this._图片 != value))
				{
					this.On图片Changing(value);
					this.SendPropertyChanging();
					this._图片 = value;
					this.SendPropertyChanged("图片");
					this.On图片Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_价格", DbType="Int")]
		public System.Nullable<int> 价格
		{
			get
			{
				return this._价格;
			}
			set
			{
				if ((this._价格 != value))
				{
					this.On价格Changing(value);
					this.SendPropertyChanging();
					this._价格 = value;
					this.SendPropertyChanged("价格");
					this.On价格Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_技术参数", DbType="NVarChar(255)")]
		public string 技术参数
		{
			get
			{
				return this._技术参数;
			}
			set
			{
				if ((this._技术参数 != value))
				{
					this.On技术参数Changing(value);
					this.SendPropertyChanging();
					this._技术参数 = value;
					this.SendPropertyChanged("技术参数");
					this.On技术参数Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_品牌", DbType="NVarChar(255)")]
		public string 品牌
		{
			get
			{
				return this._品牌;
			}
			set
			{
				if ((this._品牌 != value))
				{
					this.On品牌Changing(value);
					this.SendPropertyChanging();
					this._品牌 = value;
					this.SendPropertyChanged("品牌");
					this.On品牌Changed();
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_资料路径", DbType="NVarChar(255)")]
		public string 资料路径
		{
			get
			{
				return this._资料路径;
			}
			set
			{
				if ((this._资料路径 != value))
				{
					this.On资料路径Changing(value);
					this.SendPropertyChanging();
					this._资料路径 = value;
					this.SendPropertyChanged("资料路径");
					this.On资料路径Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_是否提交", DbType="NChar(10)")]
		public string 是否提交
		{
			get
			{
				return this._是否提交;
			}
			set
			{
				if ((this._是否提交 != value))
				{
					this.On是否提交Changing(value);
					this.SendPropertyChanging();
					this._是否提交 = value;
					this.SendPropertyChanged("是否提交");
					this.On是否提交Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_是否审核", DbType="NVarChar(10)")]
		public string 是否审核
		{
			get
			{
				return this._是否审核;
			}
			set
			{
				if ((this._是否审核 != value))
				{
					this.On是否审核Changing(value);
					this.SendPropertyChanging();
					this._是否审核 = value;
					this.SendPropertyChanged("是否审核");
					this.On是否审核Changed();
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_审核日期", DbType="NVarChar(20)")]
		public string 审核日期
		{
			get
			{
				return this._审核日期;
			}
			set
			{
				if ((this._审核日期 != value))
				{
					this.On审核日期Changing(value);
					this.SendPropertyChanging();
					this._审核日期 = value;
					this.SendPropertyChanged("审核日期");
					this.On审核日期Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_新增日期", DbType="NVarChar(20)")]
		public string 新增日期
		{
			get
			{
				return this._新增日期;
			}
			set
			{
				if ((this._新增日期 != value))
				{
					this.On新增日期Changing(value);
					this.SendPropertyChanging();
					this._新增日期 = value;
					this.SendPropertyChanged("新增日期");
					this.On新增日期Changed();
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
