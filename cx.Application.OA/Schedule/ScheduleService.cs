﻿using cx.DataBase.Repository;
using cx.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace cx.Application.OA.Schedule
{
    /// <summary>
    /// 版 本 v1.0 辰星科技开发框架
    /// Copyright (c) 山西辰星昇软件科技有限公司
    /// 创建人：辰星-框架开发组
    /// 日 期：2018.07.11
    /// 描 述：日程管理
    /// </summary>
    public class ScheduleService : RepositoryFactory
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns>返回列表</returns>
        public IEnumerable<ScheduleEntity> GetList()
        {
            try
            {
                return this.BaseRepository().FindList<ScheduleEntity>();
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                    throw;
                else
                    throw ExceptionEx.ThrowServiceException(ex);
            }
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public ScheduleEntity GetEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<ScheduleEntity>(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                    throw;
                else
                    throw ExceptionEx.ThrowServiceException(ex);
            }
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            try
            {
                this.BaseRepository().Delete(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                    throw;
                else
                    throw ExceptionEx.ThrowServiceException(ex);
            }
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, ScheduleEntity entity)
        {
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    entity.Modify(keyValue);
                    this.BaseRepository().Update(entity);
                }
                else
                {
                    entity.Create();
                    this.BaseRepository().Insert(entity);
                }
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                    throw;
                else
                    throw ExceptionEx.ThrowServiceException(ex);
            }
        }
        #endregion
    }
}
