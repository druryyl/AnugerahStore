using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.Accounting.Dal;
using AnugerahBackend.Accounting.Model;
using FluentAssertions;
using Ics.Helper.Database;
using Ics.Helper.Extensions;

namespace AnugerahUnitTest.Accounting.Dal
{
    public interface IBiayaDalTest
    {
        void InsertTest();
        void UpdateTest();
        void DeletetTest();
        void GetDataTest();
        void ListDataTest();
    }

    public class BiayaDalTest : IBiayaDalTest
    {
        private IBiayaDal _biayaDal;

        public BiayaDalTest()
        {
            _biayaDal = new BiayaDal();
        }

        private BiayaModel BiayaDataFactory()
        {
            var result = new BiayaModel
            {
                BiayaID = "A1",
                Tgl = "11-02-2019",
                Jam = "01:38:00",
                Keterangan = "B1",
                NilaiBiaya = 300000
            };
            return result;
        }

        public void InsertTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = BiayaDataFactory();

                //  act
                _biayaDal.Insert(expected);


                //  assert
            }
        }

        public void UpdateTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = BiayaDataFactory();
                _biayaDal.Insert(expected);

                //  act
                _biayaDal.Update(expected);

                //  assert
            }
        }

        public void DeletetTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = BiayaDataFactory();
                _biayaDal.Insert(expected);

                //  act
                _biayaDal.Delete("A1");

                //  assert
            }
        }

        public void GetDataTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = BiayaDataFactory();
                _biayaDal.Insert(expected);

                //  act
                var actual = _biayaDal.GetData("A1");

                //  assert
                actual.Should().BeEquivalentTo(expected);
            }
        }

        public void ListDataTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected1 = BiayaDataFactory();
                _biayaDal.Insert(expected1);
                var expected2 = expected1.CloneObject();
                expected2.BiayaID = "A2";
                _biayaDal.Insert(expected2);

                var expected = new List<BiayaModel>
                {
                    expected1, expected2
                };

                //  act
                var actual = _biayaDal.ListData(expected1.Tgl, expected1.Tgl);

                //  assert
                actual.Should().BeEquivalentTo(expected1);
            }
        }
    }
}
