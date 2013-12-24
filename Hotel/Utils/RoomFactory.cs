using HotelEden.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelEden.Utils
{
    public static class RoomFactory
    {
        public static List<RoomType> GetAllRooms()
        {
            List<RoomType> rooms = new List<RoomType>();
            foreach(RoomTypes enumValue in Enum.GetValues(typeof(RoomTypes)).Cast<RoomTypes>())
            {
                rooms.Add(GetSpecificRoomType(enumValue));
            }

            return rooms;
        }

        public static RoomType GetSpecificRoomType(RoomTypes enumValue)
        {
            switch(enumValue)
            {
                case RoomTypes.Matrimonial:
                    {
                        return new RoomType{
                            Id=1,
                            Description= SpanishResources.RoomSingleDescription,
                            Title = SpanishResources.RoomMatrimonialKeyword,
                            MaxGuestNo = Convert.ToInt32(SpanishResources.RoomSingleMaxGuests),
                            Rate = Convert.ToDouble(SpanishResources.RoomSingleRate),
                            ShortDescription = SpanishResources.RoomSingleShortDescription,
                            URL = SpanishResources.RoomSingleURL,
                            ImageURL = SpanishResources.RoomSingleImageURL,
                            ThumbURL = SpanishResources.RoomSingleThumbURL,
                            Keyword = SpanishResources.RoomMatrimonialKeyword
                        };
                    }

                case RoomTypes.DoubleSimple:
                    {
                        return new RoomType{
                                Id=2,
                                Description= SpanishResources.RoomSingleDescription,
                                Title = SpanishResources.RoomDoubleSimpleKeyword,
                                MaxGuestNo = Convert.ToInt32(SpanishResources.RoomDoubleMaxGuests),
                                Rate = Convert.ToDouble(SpanishResources.RoomSingleRate),
                                ShortDescription = SpanishResources.RoomSingleShortDescription,
                                URL = SpanishResources.RoomSingleURL,
                                ImageURL = SpanishResources.RoomDoubleImageURL,
                                ThumbURL = SpanishResources.RoomSingleThumbURL,
                                Keyword = SpanishResources.RoomDoubleSimpleKeyword
                        };
                    }

                case RoomTypes.MatrimonialAndSimple:
                    {
                        return new RoomType{
                                Id=3,
                                Description= SpanishResources.RoomSingleDescription,
                                Title = SpanishResources.RoomMatrimonialAndSimpleKeyword,
                                MaxGuestNo = Convert.ToInt32(SpanishResources.RoomTripleMaxGuests),
                                Rate = Convert.ToDouble(SpanishResources.RoomSingleRate),
                                ShortDescription = SpanishResources.RoomSingleShortDescription,
                                URL = SpanishResources.RoomSingleURL,
                                ImageURL = SpanishResources.RoomTripleImageURL,
                                ThumbURL = SpanishResources.RoomSingleThumbURL,
                                Keyword = SpanishResources.RoomMatrimonialAndSimpleKeyword
                        };
                    }

                case RoomTypes.MatrimonialAndDoubleSimple:
                    {
                        return new RoomType
                        {
                            Id = 4,
                            Description = SpanishResources.RoomSingleDescription,
                            Title = SpanishResources.RoomMatrimonialAndDoubleSimpleKeyword,
                            MaxGuestNo = Convert.ToInt32(SpanishResources.RoomQuadrupleMaxGuests),
                            Rate = Convert.ToDouble(SpanishResources.RoomSingleRate),
                            ShortDescription = SpanishResources.RoomSingleShortDescription,
                            URL = SpanishResources.RoomSingleURL,
                            ImageURL = SpanishResources.RoomQuadrupleIURL,
                            ThumbURL = SpanishResources.RoomMatrimonialAndDoubleSimpleKeyword,
                            Keyword= SpanishResources.RoomMatrimonialAndDoubleSimpleKeyword
                        };
                    }

                case RoomTypes.TripleSimple:
                    {
                        return new RoomType
                        {
                            Id = 4,
                            Description = SpanishResources.RoomSingleDescription,
                            Title = SpanishResources.RoomTripleSimpleKeyword,
                            MaxGuestNo = Convert.ToInt32(SpanishResources.RoomQuadrupleMaxGuests),
                            Rate = Convert.ToDouble(SpanishResources.RoomSingleRate),
                            ShortDescription = SpanishResources.RoomSingleShortDescription,
                            URL = SpanishResources.RoomSingleURL,
                            ImageURL = SpanishResources.RoomQuadrupleIURL,
                            ThumbURL = SpanishResources.RoomTripleSimpleKeyword,
                            Keyword = SpanishResources.RoomTripleSimpleKeyword
                        };
                    }

                case RoomTypes.QuadrupleSimple:
                    {
                        return new RoomType
                        {
                            Id = 4,
                            Description = SpanishResources.RoomSingleDescription,
                            Title = SpanishResources.RoomQuadrupleSimpleKeyword,
                            MaxGuestNo = Convert.ToInt32(SpanishResources.RoomQuadrupleMaxGuests),
                            Rate = Convert.ToDouble(SpanishResources.RoomSingleRate),
                            ShortDescription = SpanishResources.RoomSingleShortDescription,
                            URL = SpanishResources.RoomSingleURL,
                            ImageURL = SpanishResources.RoomQuadrupleIURL,
                            ThumbURL = SpanishResources.RoomQuadrupleSimpleKeyword,
                            Keyword = SpanishResources.RoomQuadrupleSimpleKeyword
                        };
                    }

                case RoomTypes.DoubleMatrimonial:
                    {
                        return new RoomType
                        {
                            Id = 4,
                            Description = SpanishResources.RoomSingleDescription,
                            Title = SpanishResources.RoomDoubleMatrimonialKeyword,
                            MaxGuestNo = Convert.ToInt32(SpanishResources.RoomQuadrupleMaxGuests),
                            Rate = Convert.ToDouble(SpanishResources.RoomSingleRate),
                            ShortDescription = SpanishResources.RoomSingleShortDescription,
                            URL = SpanishResources.RoomSingleURL,
                            ImageURL = SpanishResources.RoomQuadrupleIURL,
                            ThumbURL = SpanishResources.RoomQuadrupleSimpleKeyword,
                            Keyword = SpanishResources.RoomDoubleMatrimonialKeyword
                        };
                    }

                default:
                    {
                        return new RoomType
                        {
                            Id = 1,
                            Description = SpanishResources.RoomSingleDescription,
                            Title = SpanishResources.RoomSingleTitle,
                            MaxGuestNo = Convert.ToInt32(SpanishResources.RoomSingleMaxGuests),
                            Rate = Convert.ToDouble(SpanishResources.RoomSingleRate),
                            ShortDescription = SpanishResources.RoomSingleShortDescription,
                            URL = SpanishResources.RoomSingleURL,
                            ImageURL = SpanishResources.RoomSingleImageURL,
                            ThumbURL = SpanishResources.RoomSingleThumbURL,
                            Keyword = SpanishResources.RoomSingleKeyword
                        };
                    }

            }
                
                
        }
    }

    public enum RoomTypes
    {
        Matrimonial,
        DoubleSimple,
        MatrimonialAndSimple,
        MatrimonialAndDoubleSimple,
        DoubleMatrimonial,
        TripleSimple,
        QuadrupleSimple
    }
}