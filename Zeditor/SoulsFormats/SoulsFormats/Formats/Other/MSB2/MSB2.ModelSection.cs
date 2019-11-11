﻿using System;
using System.Collections.Generic;

namespace SoulsFormats
{
    public partial class MSB2
    {
        /// <summary>
        /// A section containing all the models available to parts in this map.
        /// </summary>
        public class ModelSection : Section<Model>
        {
            internal override string Type => "MODEL_PARAM_ST";

            /// <summary>
            /// Map piece models in this section.
            /// </summary>
            public List<Model> MapPieces;

            /// <summary>
            /// Object models in this section.
            /// </summary>
            public List<Model> Objects;

            /// <summary>
            /// Enemy models in this section.
            /// </summary>
            public List<Model> Enemies;

            /// <summary>
            /// Items in this section.
            /// </summary>
            public List<Model> Items;

            /// <summary>
            /// Player models in this section.
            /// </summary>
            public List<Model> Players;

            /// <summary>
            /// Collision models in this section.
            /// </summary>
            public List<Model> Collisions;

            /// <summary>
            /// Other models in this section.
            /// </summary>
            public List<Model> Others;

            internal ModelSection(BinaryReaderEx br, int unk1) : base(br, unk1)
            {
                MapPieces = new List<Model>();
                Objects = new List<Model>();
                Enemies = new List<Model>();
                Items = new List<Model>();
                Players = new List<Model>();
                Collisions = new List<Model>();
                Others = new List<Model>();
            }

            /// <summary>
            /// Returns every model in the order they will be written.
            /// </summary>
            public override List<Model> GetEntries()
            {
                return SFUtil.ConcatAll<Model>(
                    MapPieces, Objects, Enemies, Items, Players, Collisions, Others);
            }

            internal override Model ReadEntry(BinaryReaderEx br)
            {
                ModelType type = br.GetEnum16<ModelType>(br.Position + 8);

                switch (type)
                {
                    case ModelType.MapPiece:
                        var mapPiece = new Model(br);
                        MapPieces.Add(mapPiece);
                        return mapPiece;

                    case ModelType.Object:
                        var obj = new Model(br);
                        Objects.Add(obj);
                        return obj;

                    case ModelType.Enemy:
                        var enemy = new Model(br);
                        Enemies.Add(enemy);
                        return enemy;

                    case ModelType.Item:
                        var item = new Model(br);
                        Items.Add(item);
                        return item;

                    case ModelType.Player:
                        var player = new Model(br);
                        Players.Add(player);
                        return player;

                    case ModelType.Collision:
                        var collision = new Model(br);
                        Collisions.Add(collision);
                        return collision;

                    case ModelType.Other:
                        var other = new Model(br);
                        Others.Add(other);
                        return other;

                    default:
                        throw new NotImplementedException($"Unsupported model type: {type}");
                }
            }

            internal override void WriteEntries(BinaryWriterEx bw, List<Model> entries)
            {
                throw new NotImplementedException();
            }
        }

        internal enum ModelType : ushort
        {
            MapPiece = 0,
            Object = 1,
            Enemy = 2,
            Item = 3,
            Player = 4,
            Collision = 5,
            Navmesh = 6,
            DummyObject = 7,
            DummyEnemy = 8,
            Other = 0xFFFF
        }

        /// <summary>
        /// A model available for use by parts in this map.
        /// </summary>
        public class Model : Entry
        {
            internal ModelType Type { get; private set; }

            /// <summary>
            /// The name of this model.
            /// </summary>
            public override string Name { get; set; }

            internal Model(BinaryReaderEx br)
            {
                long start = br.Position;

                long nameOffset = br.ReadInt64();
                Type = br.ReadEnum16<ModelType>();

                Name = br.GetUTF16(start + nameOffset);
            }

            /// <summary>
            /// Returns the model type and name of this model.
            /// </summary>
            public override string ToString()
            {
                return $"{Type} : {Name}";
            }
        }
    }
}
