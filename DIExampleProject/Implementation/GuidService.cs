using System;
using DIExampleProject.Interfaces;

namespace DIExampleProject.Implementation
{
    public class GuidService : IGuidService
    {
        private readonly Guid _guid = Guid.NewGuid();
        public Guid GetGuid() => _guid;
    }
}