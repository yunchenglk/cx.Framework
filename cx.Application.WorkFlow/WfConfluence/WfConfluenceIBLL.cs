﻿
using System.Collections.Generic;
namespace cx.Application.WorkFlow
{
    /// <summary>
    /// 版 本 v1.0 辰星科技开发框架
    /// Copyright (c) 山西辰星昇软件科技有限公司
    /// 创建人：辰星-框架开发组
    /// 日 期：2018.04.17
    /// 描 述：会签记录操作
    /// </summary>
    public interface WfConfluenceIBLL
    {
        #region 获取数据
        /// <summary>
        /// 获取会签记录
        /// </summary>
        /// <param name="processId">流程实例主键</param>
        /// <param name="nodeId">节点主键</param>
        /// <returns></returns>
        IEnumerable<WfConfluenceEntity> GetList(string processId, string nodeId);
        #endregion

        #region 提交数据
        /// <summary>
        /// 保存成功的会前记录
        /// </summary>
        /// <param name="entity">实体</param>
        void SaveEntity(WfConfluenceEntity entity);
        /// <summary>
        /// 删除会签节点数据
        /// </summary>
        /// <param name="processId">实例主键</param>
        /// <param name="nodeId">节点主键</param>
        void DeleteEntity(string processId, string nodeId);
        #endregion
    }
}
