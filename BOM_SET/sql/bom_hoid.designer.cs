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
	public partial class bom_hoidDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region 可扩展性方法定义
    partial void OnCreated();
    partial void InsertTable_BOM_HOLD(Table_BOM_HOLD instance);
    partial void UpdateTable_BOM_HOLD(Table_BOM_HOLD instance);
    partial void DeleteTable_BOM_HOLD(Table_BOM_HOLD instance);
    #endregion
		
		public bom_hoidDataContext() : 
				base(global::BOM_SET.Properties.Settings.Default.Database1_mdfConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public bom_hoidDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public bom_hoidDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public bom_hoidDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public bom_hoidDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Table_BOM_HOLD> Table_BOM_HOLD
		{
			get
			{
				return this.GetTable<Table_BOM_HOLD>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Table_BOM_HOLD")]
	public partial class Table_BOM_HOLD : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private int _project_ID;
		
		private string _项目代号;
		
		private string _项目名称;
		
		private string _类别;
		
		private string _设备序号;
		
		private string _第几次申请;
		
		private string _密钥;
		
		private string _备注;
		
		private System.Nullable<int> _项目负责人ID;
		
		private System.Nullable<int> _最后修改人ID;
		
		private string _是否激活;
		
		private string _是否提交申请;
		
		private string _当次审批是否通过;
		
		private string _是否已获过审批;
		
		private string _当次计划是否提完;
		
		private string _是否已提计划;
		
		private string _当次采购是否完成;
		
		private string _是否已提采购;
		
		private string _项目经理;
		
		private string _项目开始时间;
		
		private string _项目开始采购时间;
		
		private string _项目截止采购时间;
		
		private string _项目调试开始时间;
		
		private string _项目调试结束时间;
		
		private string _项目预验收时间;
		
		private string _项目是否已验收;
		
		private string _项目终验收时间;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void Onproject_IDChanging(int value);
    partial void Onproject_IDChanged();
    partial void On项目代号Changing(string value);
    partial void On项目代号Changed();
    partial void On项目名称Changing(string value);
    partial void On项目名称Changed();
    partial void On类别Changing(string value);
    partial void On类别Changed();
    partial void On设备序号Changing(string value);
    partial void On设备序号Changed();
    partial void On第几次申请Changing(string value);
    partial void On第几次申请Changed();
    partial void On密钥Changing(string value);
    partial void On密钥Changed();
    partial void On备注Changing(string value);
    partial void On备注Changed();
    partial void On项目负责人IDChanging(System.Nullable<int> value);
    partial void On项目负责人IDChanged();
    partial void On最后修改人IDChanging(System.Nullable<int> value);
    partial void On最后修改人IDChanged();
    partial void On是否激活Changing(string value);
    partial void On是否激活Changed();
    partial void On是否提交申请Changing(string value);
    partial void On是否提交申请Changed();
    partial void On当次审批是否通过Changing(string value);
    partial void On当次审批是否通过Changed();
    partial void On是否已获过审批Changing(string value);
    partial void On是否已获过审批Changed();
    partial void On当次计划是否提完Changing(string value);
    partial void On当次计划是否提完Changed();
    partial void On是否已提计划Changing(string value);
    partial void On是否已提计划Changed();
    partial void On当次采购是否完成Changing(string value);
    partial void On当次采购是否完成Changed();
    partial void On是否已提采购Changing(string value);
    partial void On是否已提采购Changed();
    partial void On项目经理Changing(string value);
    partial void On项目经理Changed();
    partial void On项目开始时间Changing(string value);
    partial void On项目开始时间Changed();
    partial void On项目开始采购时间Changing(string value);
    partial void On项目开始采购时间Changed();
    partial void On项目截止采购时间Changing(string value);
    partial void On项目截止采购时间Changed();
    partial void On项目调试开始时间Changing(string value);
    partial void On项目调试开始时间Changed();
    partial void On项目调试结束时间Changing(string value);
    partial void On项目调试结束时间Changed();
    partial void On项目预验收时间Changing(string value);
    partial void On项目预验收时间Changed();
    partial void On项目是否已验收Changing(string value);
    partial void On项目是否已验收Changed();
    partial void On项目终验收时间Changing(string value);
    partial void On项目终验收时间Changed();
    #endregion
		
		public Table_BOM_HOLD()
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_project_ID", DbType="Int NOT NULL")]
		public int project_ID
		{
			get
			{
				return this._project_ID;
			}
			set
			{
				if ((this._project_ID != value))
				{
					this.Onproject_IDChanging(value);
					this.SendPropertyChanging();
					this._project_ID = value;
					this.SendPropertyChanged("project_ID");
					this.Onproject_IDChanged();
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_项目名称", DbType="NChar(10)")]
		public string 项目名称
		{
			get
			{
				return this._项目名称;
			}
			set
			{
				if ((this._项目名称 != value))
				{
					this.On项目名称Changing(value);
					this.SendPropertyChanging();
					this._项目名称 = value;
					this.SendPropertyChanged("项目名称");
					this.On项目名称Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_类别", DbType="NChar(10)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_设备序号", DbType="NChar(10)")]
		public string 设备序号
		{
			get
			{
				return this._设备序号;
			}
			set
			{
				if ((this._设备序号 != value))
				{
					this.On设备序号Changing(value);
					this.SendPropertyChanging();
					this._设备序号 = value;
					this.SendPropertyChanged("设备序号");
					this.On设备序号Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_第几次申请", DbType="NChar(10)")]
		public string 第几次申请
		{
			get
			{
				return this._第几次申请;
			}
			set
			{
				if ((this._第几次申请 != value))
				{
					this.On第几次申请Changing(value);
					this.SendPropertyChanging();
					this._第几次申请 = value;
					this.SendPropertyChanged("第几次申请");
					this.On第几次申请Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_密钥", DbType="NChar(10)")]
		public string 密钥
		{
			get
			{
				return this._密钥;
			}
			set
			{
				if ((this._密钥 != value))
				{
					this.On密钥Changing(value);
					this.SendPropertyChanging();
					this._密钥 = value;
					this.SendPropertyChanged("密钥");
					this.On密钥Changed();
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_项目负责人ID", DbType="Int")]
		public System.Nullable<int> 项目负责人ID
		{
			get
			{
				return this._项目负责人ID;
			}
			set
			{
				if ((this._项目负责人ID != value))
				{
					this.On项目负责人IDChanging(value);
					this.SendPropertyChanging();
					this._项目负责人ID = value;
					this.SendPropertyChanged("项目负责人ID");
					this.On项目负责人IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_最后修改人ID", DbType="Int")]
		public System.Nullable<int> 最后修改人ID
		{
			get
			{
				return this._最后修改人ID;
			}
			set
			{
				if ((this._最后修改人ID != value))
				{
					this.On最后修改人IDChanging(value);
					this.SendPropertyChanging();
					this._最后修改人ID = value;
					this.SendPropertyChanged("最后修改人ID");
					this.On最后修改人IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_是否激活", DbType="NChar(10)")]
		public string 是否激活
		{
			get
			{
				return this._是否激活;
			}
			set
			{
				if ((this._是否激活 != value))
				{
					this.On是否激活Changing(value);
					this.SendPropertyChanging();
					this._是否激活 = value;
					this.SendPropertyChanged("是否激活");
					this.On是否激活Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_是否提交申请", DbType="NChar(10)")]
		public string 是否提交申请
		{
			get
			{
				return this._是否提交申请;
			}
			set
			{
				if ((this._是否提交申请 != value))
				{
					this.On是否提交申请Changing(value);
					this.SendPropertyChanging();
					this._是否提交申请 = value;
					this.SendPropertyChanged("是否提交申请");
					this.On是否提交申请Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_当次审批是否通过", DbType="NChar(10)")]
		public string 当次审批是否通过
		{
			get
			{
				return this._当次审批是否通过;
			}
			set
			{
				if ((this._当次审批是否通过 != value))
				{
					this.On当次审批是否通过Changing(value);
					this.SendPropertyChanging();
					this._当次审批是否通过 = value;
					this.SendPropertyChanged("当次审批是否通过");
					this.On当次审批是否通过Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_是否已获过审批", DbType="NChar(10)")]
		public string 是否已获过审批
		{
			get
			{
				return this._是否已获过审批;
			}
			set
			{
				if ((this._是否已获过审批 != value))
				{
					this.On是否已获过审批Changing(value);
					this.SendPropertyChanging();
					this._是否已获过审批 = value;
					this.SendPropertyChanged("是否已获过审批");
					this.On是否已获过审批Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_当次计划是否提完", DbType="NChar(10)")]
		public string 当次计划是否提完
		{
			get
			{
				return this._当次计划是否提完;
			}
			set
			{
				if ((this._当次计划是否提完 != value))
				{
					this.On当次计划是否提完Changing(value);
					this.SendPropertyChanging();
					this._当次计划是否提完 = value;
					this.SendPropertyChanged("当次计划是否提完");
					this.On当次计划是否提完Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_是否已提计划", DbType="NChar(10)")]
		public string 是否已提计划
		{
			get
			{
				return this._是否已提计划;
			}
			set
			{
				if ((this._是否已提计划 != value))
				{
					this.On是否已提计划Changing(value);
					this.SendPropertyChanging();
					this._是否已提计划 = value;
					this.SendPropertyChanged("是否已提计划");
					this.On是否已提计划Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_当次采购是否完成", DbType="NChar(10)")]
		public string 当次采购是否完成
		{
			get
			{
				return this._当次采购是否完成;
			}
			set
			{
				if ((this._当次采购是否完成 != value))
				{
					this.On当次采购是否完成Changing(value);
					this.SendPropertyChanging();
					this._当次采购是否完成 = value;
					this.SendPropertyChanged("当次采购是否完成");
					this.On当次采购是否完成Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_是否已提采购", DbType="NChar(10)")]
		public string 是否已提采购
		{
			get
			{
				return this._是否已提采购;
			}
			set
			{
				if ((this._是否已提采购 != value))
				{
					this.On是否已提采购Changing(value);
					this.SendPropertyChanging();
					this._是否已提采购 = value;
					this.SendPropertyChanged("是否已提采购");
					this.On是否已提采购Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_项目经理", DbType="NChar(10)")]
		public string 项目经理
		{
			get
			{
				return this._项目经理;
			}
			set
			{
				if ((this._项目经理 != value))
				{
					this.On项目经理Changing(value);
					this.SendPropertyChanging();
					this._项目经理 = value;
					this.SendPropertyChanged("项目经理");
					this.On项目经理Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_项目开始时间", DbType="NChar(20)")]
		public string 项目开始时间
		{
			get
			{
				return this._项目开始时间;
			}
			set
			{
				if ((this._项目开始时间 != value))
				{
					this.On项目开始时间Changing(value);
					this.SendPropertyChanging();
					this._项目开始时间 = value;
					this.SendPropertyChanged("项目开始时间");
					this.On项目开始时间Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_项目开始采购时间", DbType="NChar(20)")]
		public string 项目开始采购时间
		{
			get
			{
				return this._项目开始采购时间;
			}
			set
			{
				if ((this._项目开始采购时间 != value))
				{
					this.On项目开始采购时间Changing(value);
					this.SendPropertyChanging();
					this._项目开始采购时间 = value;
					this.SendPropertyChanged("项目开始采购时间");
					this.On项目开始采购时间Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_项目截止采购时间", DbType="NChar(20)")]
		public string 项目截止采购时间
		{
			get
			{
				return this._项目截止采购时间;
			}
			set
			{
				if ((this._项目截止采购时间 != value))
				{
					this.On项目截止采购时间Changing(value);
					this.SendPropertyChanging();
					this._项目截止采购时间 = value;
					this.SendPropertyChanged("项目截止采购时间");
					this.On项目截止采购时间Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_项目调试开始时间", DbType="NChar(20)")]
		public string 项目调试开始时间
		{
			get
			{
				return this._项目调试开始时间;
			}
			set
			{
				if ((this._项目调试开始时间 != value))
				{
					this.On项目调试开始时间Changing(value);
					this.SendPropertyChanging();
					this._项目调试开始时间 = value;
					this.SendPropertyChanged("项目调试开始时间");
					this.On项目调试开始时间Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_项目调试结束时间", DbType="NChar(20)")]
		public string 项目调试结束时间
		{
			get
			{
				return this._项目调试结束时间;
			}
			set
			{
				if ((this._项目调试结束时间 != value))
				{
					this.On项目调试结束时间Changing(value);
					this.SendPropertyChanging();
					this._项目调试结束时间 = value;
					this.SendPropertyChanged("项目调试结束时间");
					this.On项目调试结束时间Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_项目预验收时间", DbType="NChar(20)")]
		public string 项目预验收时间
		{
			get
			{
				return this._项目预验收时间;
			}
			set
			{
				if ((this._项目预验收时间 != value))
				{
					this.On项目预验收时间Changing(value);
					this.SendPropertyChanging();
					this._项目预验收时间 = value;
					this.SendPropertyChanged("项目预验收时间");
					this.On项目预验收时间Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_项目是否已验收", DbType="NChar(10)")]
		public string 项目是否已验收
		{
			get
			{
				return this._项目是否已验收;
			}
			set
			{
				if ((this._项目是否已验收 != value))
				{
					this.On项目是否已验收Changing(value);
					this.SendPropertyChanging();
					this._项目是否已验收 = value;
					this.SendPropertyChanged("项目是否已验收");
					this.On项目是否已验收Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_项目终验收时间", DbType="NChar(20)")]
		public string 项目终验收时间
		{
			get
			{
				return this._项目终验收时间;
			}
			set
			{
				if ((this._项目终验收时间 != value))
				{
					this.On项目终验收时间Changing(value);
					this.SendPropertyChanging();
					this._项目终验收时间 = value;
					this.SendPropertyChanged("项目终验收时间");
					this.On项目终验收时间Changed();
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
