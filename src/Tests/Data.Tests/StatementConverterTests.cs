﻿using Doctrina.ExperienceApi.Data.Json;
using Shouldly;
using Xunit;

namespace Doctrina.ExperienceApi.Data.Tests
{
    public class StatementConverterTests
    {
        [Fact]
        public void DerserializeLongStatement()
        {
            var serializer = new JSerializer();
            string json = @"{
    ""id"": ""6690e6c9-3ef0-4ed3-8b37-7f3964730bee"",
    ""actor"": {
                ""name"": ""Team PB"",
        ""mbox"": ""mailto:teampb@example.com"",
        ""member"": [
            {
                    ""name"": ""Andrew Downes"",
                ""account"": {
                        ""homePage"": ""http://www.example.com"",
                    ""name"": ""13936749""
                },
                ""objectType"": ""Agent""
            },
            {
                    ""name"": ""Toby Nichols"",
                ""openid"": ""http://toby.openid.example.org/"",
                ""objectType"": ""Agent""
            },
            {
                    ""name"": ""Ena Hills"",
                ""mbox_sha1sum"": ""ebd31e95054c018b10727ccffd2ef2ec3a016ee9"",
                ""objectType"": ""Agent""
            }
        ],
        ""objectType"": ""Group""
    },
    ""verb"": {
                ""id"": ""http://adlnet.gov/expapi/verbs/attended"",
        ""display"": {
                    ""en-GB"": ""attended"",
            ""en-US"": ""attended""
        }
            },
    ""result"": {
                ""extensions"": {
                    ""http://example.com/profiles/meetings/resultextensions/minuteslocation"": ""X:\\meetings\\minutes\\examplemeeting.one""
                },
        ""success"": true,
        ""completion"": true,
        ""response"": ""We agreed on some example actions."",
        ""duration"": ""PT1H0M0S""
    },
    ""context"": {
                ""registration"": ""ec531277-b57b-4c15-8d91-d292c5b2b8f7"",
        ""contextActivities"": {
                    ""parent"": [
                        {
                        ""id"": ""http://www.example.com/meetings/series/267"",
                    ""objectType"": ""Activity""
                        }
            ],
            ""category"": [
                {
                        ""id"": ""http://www.example.com/meetings/categories/teammeeting"",
                    ""objectType"": ""Activity"",
                    ""definition"": {
                            ""name"": {
                                ""en"": ""team meeting""
    
                        },
			            ""description"": {
                                ""en"": ""A category of meeting used for regular team meetings.""

                        },
			            ""type"": ""http://example.com/expapi/activities/meetingcategory""

                    }
                    }
            ],
            ""other"": [
                {
                        ""id"": ""http://www.example.com/meetings/occurances/34257"",
                    ""objectType"": ""Activity""
                },
                {
                        ""id"": ""http://www.example.com/meetings/occurances/3425567"",
                    ""objectType"": ""Activity""
                }
            ]
        },
        ""instructor"" :
        {
                    ""name"": ""Andrew Downes"",
            ""account"": {
                        ""homePage"": ""http://www.example.com"",
                ""name"": ""13936749""
            },
            ""objectType"": ""Agent""
        },
        ""team"":
        {
                    ""name"": ""Team PB"",
        	""mbox"": ""mailto:teampb@example.com"",
        	""objectType"": ""Group""
        }, 
        ""platform"" : ""Example virtual meeting software"",
        ""language"" : ""tlh"",
        ""statement"" : {
                    ""objectType"":""StatementRef"",
        	""id"" :""6690e6c9-3ef0-4ed3-8b37-7f3964730bee""
        }

            },
    ""timestamp"": ""2013-05-18T05:32:34.804+00:00"",
    ""stored"": ""2013-05-18T05:32:34.804+00:00"",
    ""authority"": {
                ""account"": {
                    ""homePage"": ""http://cloud.scorm.com/"",
            ""name"": ""anonymous""
                },
        ""objectType"": ""Agent""
    },
    ""version"": ""1.0.0"",
    ""object"": {
                ""id"": ""http://www.example.com/meetings/occurances/34534"",
        ""definition"": {
                    ""extensions"": {
                        ""http://example.com/profiles/meetings/activitydefinitionextensions/room"": { ""name"": ""Kilby"", ""id"" : ""http://example.com/rooms/342""}
                    },
            ""name"": {
                        ""en-GB"": ""example meeting"",
                ""en-US"": ""example meeting""
            },
            ""description"": {
                        ""en-GB"": ""An example meeting that happened on a specific occasion with certain people present."",
                ""en-US"": ""An example meeting that happened on a specific occasion with certain people present.""
            },
            ""type"": ""http://adlnet.gov/expapi/activities/meeting"",
            ""moreInfo"": ""http://virtualmeeting.example.com/345256""
        },
        ""objectType"": ""Activity""
    }
        }";
            var statement = serializer.Deserialize<Statement>(json);
            statement.Id.ShouldNotBeNull();
            statement.Id.ToString().ShouldBe("6690e6c9-3ef0-4ed3-8b37-7f3964730bee");
            statement.Actor.ShouldNotBeNull();
            statement.Version.ShouldBe("1.0.0");
            statement.Object.ShouldNotBeNull();
        }
    }
}
