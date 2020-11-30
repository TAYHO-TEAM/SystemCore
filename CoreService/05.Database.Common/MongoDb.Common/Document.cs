using MongoDb.Common.Interfaces;
using MongoDB.Bson;
using System;

namespace MongoDb.Common
{
    public abstract class Document : IDocument
    {
        public ObjectId Id { get; set; }
        public DateTime CreatedAt => Id.CreationTime;
    }
}