﻿using cx.Util;
using System.Collections.Generic;

namespace cx.Application.IM
{
    /// <summary>
    /// 版 本 v1.0 辰星科技开发框架
    /// Copyright (c) 山西辰星昇软件科技有限公司
    /// 创建人：辰星-框架开发组
    /// 日 期：2018.05.30
    /// 描 述：即时通讯用户注册
    /// </summary>
    public interface IMSysUserIBLL
    {
        #region 获取数据
        /// <summary>
        /// 获取列表数据
        /// </summary>
        /// <param name="keyWord">查询关键字</param>
        /// <returns></returns>
        IEnumerable<IMSysUserEntity> GetList(string keyWord);

        /// <summary>
        /// 获取列表分页数据
        /// <param name="pagination">分页参数</param>
        /// <param name="keyWord">查询关键字</param>
        /// <summary>
        /// <returns></returns>
        IEnumerable<IMSysUserEntity> GetPageList(Pagination pagination, string keyWord);

        /// <summary>
        /// 获取实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        IMSysUserEntity GetEntity(string keyValue);
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除实体数据(虚拟)
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        void DeleteEntity(string keyValue);
        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        void SaveEntity(string keyValue, IMSysUserEntity entity);
        #endregion

        #region 验证数据
        /// <summary>
        /// 规则编号不能重复
        /// </summary>
        /// <param name="code">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        bool ExistEnCode(string code, string keyValue);
        #endregion
    }
}
