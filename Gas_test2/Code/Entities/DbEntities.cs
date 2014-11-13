using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using EAS.Data;
using EAS.Data.Access;
using EAS.Data.ORM;
using EAS.Data.Linq;

namespace Gas_test2.Entities
{
   /// <summary>
   /// 数据上下文。
   /// </summary>
   public class DbEntities:DataContext
   {
        #region 字段定义

        private DataEntityQuery<EquipTypeAbl> m_EquipTypeAbls;
        private DataEntityQuery<EquipTypeSlet> m_EquipTypeSlets;
        private DataEntityQuery<AlgTypeAbl> m_AlgTypeAbls;
        private DataEntityQuery<AlgTypeSlet> m_AlgTypeSlets;
        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化DbEntities对象实例。
        /// </summary>
        public DbEntities()
        {
        }

        /// <summary>
        /// 初始化DbEntities对象实例。
        /// </summary>
        /// <param name="dbProvider">数据库访问程序提供者。</param>
        public DbEntities(IDbProvider dbProvider)
            : base(dbProvider)
        {

        }

        /// <summary>
        /// 初始化DbEntities对象实例。
        /// </summary>
        /// <param name="dataAccessor">数据访问器。</param>
        public DbEntities(IDataAccessor dataAccessor)
            : base(dataAccessor)
        {

        }

        /// <summary>
        /// 初始化DbEntities对象实例。
        /// </summary>
        /// <param name="dataAccessor">数据访问器。</param>
        /// <param name="ormAccessor">Orm访问器。</param>
        public DbEntities(IDataAccessor dataAccessor, IOrmAccessor ormAccessor)
            : base(dataAccessor, ormAccessor)
        {

        }

        #endregion

        #region 查询定义

        /// <summary>
        /// 可选设备种类表。
        /// </summary>
        public DataEntityQuery<EquipTypeAbl> EquipTypeAbls
        {
            get
            {
                if (this.m_EquipTypeAbls == null)
                {
                    this.m_EquipTypeAbls = base.CreateQuery<EquipTypeAbl>();
                }
                return this.m_EquipTypeAbls;
            }
        }

        /// <summary>
        /// 选择设备种类表。
        /// </summary>
        public DataEntityQuery<EquipTypeSlet> EquipTypeSlets
        {
            get
            {
                if (this.m_EquipTypeSlets == null)
                {
                    this.m_EquipTypeSlets = base.CreateQuery<EquipTypeSlet>();
                }
                return this.m_EquipTypeSlets;
            }
        }

        /// <summary>
        /// 可选算法种类表。
        /// </summary>
        public DataEntityQuery<AlgTypeAbl> AlgTypeAbls
        {
            get
            {
                if (this.m_AlgTypeAbls == null)
                {
                    this.m_AlgTypeAbls = base.CreateQuery<AlgTypeAbl>();
                }
                return this.m_AlgTypeAbls;
            }
        }

        /// <summary>
        /// 选择算法种类表。
        /// </summary>
        public DataEntityQuery<AlgTypeSlet> AlgTypeSlets
        {
            get
            {
                if (this.m_AlgTypeSlets == null)
                {
                    this.m_AlgTypeSlets = base.CreateQuery<AlgTypeSlet>();
                }
                return this.m_AlgTypeSlets;
            }
        }


        #endregion

   }
}
