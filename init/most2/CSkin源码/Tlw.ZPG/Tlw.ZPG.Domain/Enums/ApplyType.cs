namespace Tlw.ZPG.Domain.Enums
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// �������
    /// </summary>
    public enum ApplyType
    {
        /// ����
        /// </summary>
        [Description("����")]
        Corporation,
        /// ֪ʶ�ʴ�
        /// </summary>
        [Description("��Ȼ��")]
        Natural,
        /// ���Ͼ���
        /// </summary>
        [Description("���Ͼ���")]
        Union,
        /// ������֯
        /// </summary>
        [Description("������֯")]
        OtherOrg,
    }
}
