/**
 * This file is automatically created by Recurly's OpenAPI generation process
 * and thus any edits you make by hand will be lost. If you wish to make a
 * change to this file, please create a Github issue explaining the changes you
 * need and we will usher them to the appropriate places.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Recurly.Resources
{
    [ExcludeFromCodeCoverage]
    public class ItemUpdate : Request
    {

        /// <value>Accounting code for invoice line items.</value>
        [JsonProperty("accounting_code")]
        public string AccountingCode { get; set; }

        /// <value>Unique code to identify the item.</value>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <value>Item Pricing</value>
        [JsonProperty("currencies")]
        public List<Pricing> Currencies { get; set; }


        [JsonProperty("custom_fields")]
        public List<CustomField> CustomFields { get; set; }

        /// <value>Optional, description.</value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <value>Optional, stock keeping unit to link the item to other inventory systems.</value>
        [JsonProperty("external_sku")]
        public string ExternalSku { get; set; }

        /// <value>This name describes your item and will appear on the invoice when it's purchased on a one time basis.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <value>Revenue schedule type</value>
        [JsonProperty("revenue_schedule_type")]
        public string RevenueScheduleType { get; set; }

        /// <value>Used by Avalara, Vertex, and Recurly’s EU VAT tax feature. The tax code values are specific to each tax system. If you are using Recurly’s EU VAT feature you can use `unknown`, `physical`, or `digital`.</value>
        [JsonProperty("tax_code")]
        public string TaxCode { get; set; }

        /// <value>`true` exempts tax on the item, `false` applies tax on the item.</value>
        [JsonProperty("tax_exempt")]
        public bool? TaxExempt { get; set; }

    }
}
