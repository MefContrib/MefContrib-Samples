using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using MefContrib.Hosting.Interception;

namespace MefContrib.Samples.Filter
{
    public class PartCreationPolicyFilter : IExportHandler
    {
        private const string MetadataName = CompositionConstants.PartCreationPolicyMetadataName;

        public CreationPolicy CreationPolicy { get; private set; }
        
        public PartCreationPolicyFilter(CreationPolicy creationPolicy)
        {
            CreationPolicy = creationPolicy;
        }

        public void Initialize(ComposablePartCatalog interceptedCatalog)
        {
        }

        public IEnumerable<Tuple<ComposablePartDefinition, ExportDefinition>> GetExports(
            ImportDefinition definition,
            IEnumerable<Tuple<ComposablePartDefinition, ExportDefinition>> exports)
        {
            return from export in exports
                   where Filter(export.Item1)
                   select export;
        }

        private bool Filter(ComposablePartDefinition part)
        {
            return part.Metadata.ContainsKey(MetadataName) &&
                   part.Metadata[MetadataName].Equals(this.CreationPolicy);
        }
    }
}