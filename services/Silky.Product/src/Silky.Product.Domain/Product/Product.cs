using Silky.EntityFrameworkCore.Entities;
using Silky.Product.Domain.Depict;

namespace Silky.Product.Domain.Product
{
    public class Product : Entity<long>
    {
        #region 基本信息
        /// <summary>
        /// 类目
        /// </summary>
        public long CategoryId { get; set; }
        public virtual Category.Category Category { get; set; }

        /// <summary>
        /// 开票名称
        /// </summary>
        public long InvoiceArticleId { get; set; }
        public virtual InvoiceArticle InvoiceArticle { get; set; }

        /// <summary>
        /// 款式
        /// </summary>
        public string Pattern { get; set; }
        /// <summary>
        /// 成分
        /// </summary>
        public string Ingredient { get; set; }
        /// <summary>
        /// 英文成分
        /// </summary>
        public string EnIngredient { get; set; }

        /// <summary>
        /// 工艺
        /// </summary>
        public string Craft { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        #endregion

        #region 属性

        #endregion

        #region 规格

        #endregion

        #region SKU
        public virtual ICollection<ProductSpec> Skus { get; set; }
        #endregion

        #region 物料

        #endregion
    }
}
