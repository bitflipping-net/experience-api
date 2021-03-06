﻿using Newtonsoft.Json.Linq;

namespace Doctrina.ExperienceApi.Data.InteractionTypes
{
    public class Sequencing : InteractionActivityDefinitionBase
    {
        public Sequencing() { }

        public Sequencing(JToken jtoken, ApiVersion version) : base(jtoken, version)
        {
        }

        protected override InteractionType INTERACTION_TYPE => InteractionType.Sequencing;

        public InteractionComponent[] Choices { get; set; }
    }
}
