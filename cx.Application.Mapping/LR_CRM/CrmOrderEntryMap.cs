using cx.Application.CRM;
using System.Data.Entity.ModelConfiguration;

namespace  cx.Application.Mapping
{
    /// <summary>
    /// �� �� v1.0 ���ǿƼ��������
    /// Copyright (c) ɽ�����ǕN�����Ƽ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2018-07-10 17:59
    /// �� ������������
    /// </summary>
    public class LR_CRM_OrderEntryMap : EntityTypeConfiguration<CrmOrderProductEntity>
    {
        public LR_CRM_OrderEntryMap()
        {
            #region ��������
            //��
            this.ToTable("LR_CRM_ORDERPRODUCT");
            //����
            this.HasKey(t => t.F_OrderEntryId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
