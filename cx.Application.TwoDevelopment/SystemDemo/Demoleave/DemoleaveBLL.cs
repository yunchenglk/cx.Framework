﻿using cx.Util;
using System;
using System.Collections.Generic;
namespace cx.Application.TwoDevelopment.SystemDemo
{
    /// <summary>
    /// 版 本 v1.0 辰星科技开发框架
    /// Copyright (c) 山西辰星昇软件科技有限公司
    /// 创建人：辰星-框架开发组
    /// 日 期：2018.04.17
    /// 描 述：系统表单-请假单
    /// </summary>
    public class DemoleaveBLL : DemoleaveIBLL
    {
        private DemoleaveService demoleaveService = new DemoleaveService();

        #region 获取数据
        /// <summary>
        /// 获取请假数据列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <returns></returns>
        public IEnumerable<DemoleaveEntity> GetPageList(Pagination pagination)
        {
            try
            {
                return demoleaveService.GetPageList(pagination);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        } 
        /// <summary>
        /// 根据流程实例获取表单数据
        /// </summary>
        /// <param name="processId"></param>
        /// <returns></returns>
        public DemoleaveEntity GetEntity(string processId)
        {
            try
            {
                return demoleaveService.GetEntity(processId);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 保存更新数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体对象</param>
        public void SaveEntity(string keyValue, DemoleaveEntity entity)
        {
            try
            {
                demoleaveService.SaveEntity(keyValue, entity);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }
        #endregion
    }
}