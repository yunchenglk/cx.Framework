﻿using cx.DataBase.Repository;
using cx.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace cx.Application.AppMagager
{
    /// <summary> 
    /// 版 本 v1.0 辰星科技开发框架 
    /// Copyright (c) 山西辰星昇软件科技有限公司 
    /// 创 建：超级管理员 
    /// 日 期：2018-07-02 15:31 
    /// 描 述：App首页图片管理 
    /// </summary> 
    public class DTImgService : RepositoryFactory
    {
        #region 构造函数和属性 

        private string fieldSql;
        public DTImgService()
        {
            fieldSql = @" 
                t.F_Id, 
                t.F_Des, 
                t.F_FileName, 
                t.F_EnabledMark, 
                t.F_SortCode 
            ";
        }
        #endregion

        #region 获取数据 

        /// <summary> 
        /// 获取列表数据 
        /// <summary> 
        /// <returns></returns> 
        public IEnumerable<DTImgEntity> GetList()
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM LR_App_DTImg t WHERE t.F_EnabledMark = 1 Order by  t.F_SortCode  ");
                return this.BaseRepository().FindList<DTImgEntity>(strSql.ToString());
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        /// <summary> 
        /// 获取列表分页数据 
        /// <param name="pagination">分页参数</param> 
        /// <summary> 
        /// <returns></returns> 
        public IEnumerable<DTImgEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var queryParam = queryJson.ToJObject();
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM LR_App_DTImg t  where 1=1 ");

                // 关键字
                string keyword = "";
                if (!queryParam["keyword"].IsEmpty())
                {
                    keyword = "%" + queryParam["keyword"].ToString() + "%";
                    strSql.Append(" AND t.F_Des like @keyword ");
                }

                return this.BaseRepository().FindList<DTImgEntity>(strSql.ToString(), new { keyword }, pagination);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        /// <summary> 
        /// 获取实体数据 
        /// <param name="keyValue">主键</param> 
        /// <summary> 
        /// <returns></returns> 
        public DTImgEntity GetEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<DTImgEntity>(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        #endregion

        #region 提交数据 

        /// <summary> 
        /// 删除实体数据 
        /// <param name="keyValue">主键</param> 
        /// <summary> 
        /// <returns></returns> 
        public void DeleteEntity(string keyValue)
        {
            try
            {
                this.BaseRepository().Delete<DTImgEntity>(t => t.F_Id == keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        /// <summary> 
        /// 保存实体数据（新增、修改） 
        /// <param name="keyValue">主键</param> 
        /// <summary> 
        /// <returns></returns> 
        public void SaveEntity(string keyValue, DTImgEntity entity)
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
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        #endregion

    }
}
