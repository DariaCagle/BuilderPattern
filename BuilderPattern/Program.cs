using System;
using System.Text;

namespace BuilderPattern
{
    class Program
    {
        static void Main(string[] args)
        {

            Producer producer = new Producer();

            MusicBandBuilder builder = new RockBandBuilder();

            MusicBand rockBand = producer.Create(builder);
            Console.WriteLine(rockBand.ToString());

            builder = new PopBandBuilder();
            MusicBand popBand = producer.Create(builder);
            Console.WriteLine(popBand.ToString());

            Console.Read();
        }
    }

    abstract class MusicBandBuilder
    {
        public MusicBand MusicBand { get; private set; }
        public void CreateMusicBand()
        {
            MusicBand = new MusicBand();
        }
        public abstract void SetVocalist();
        public abstract void SetDrummer();
        public abstract void SetOtherMusicians();
    }
    // пекарь
    class Producer
    {
        public MusicBand Create(MusicBandBuilder musicBandBuilder)
        {
            musicBandBuilder.CreateMusicBand();
            musicBandBuilder.SetVocalist();
            musicBandBuilder.SetDrummer();
            musicBandBuilder.SetOtherMusicians();
            return musicBandBuilder.MusicBand;
        }
    }

    class RockBandBuilder : MusicBandBuilder
    {
        public override void SetVocalist()
        {
            MusicBand.Vocalist = new Vocalist { Sort = "Growl Singer" };
        }

        public override void SetDrummer()
        {
            MusicBand.Drummer = new Drummer();
        }

        public override void SetOtherMusicians()
        {
            MusicBand.OtherMusicians = new OtherMusicians { Name = "Guitar Player, Keyboard Player, Bass Player" };
        }
    }

    class PopBandBuilder : MusicBandBuilder
    {
        public override void SetVocalist()
        {
            MusicBand.Vocalist = new Vocalist { Sort = "Pop Singer" };
        }

        public override void SetDrummer()
        {
            MusicBand.Drummer = new Drummer();
        }

        public override void SetOtherMusicians()
        {
            MusicBand.OtherMusicians = new OtherMusicians { Name = "Keyboard Player" };
        }
    }

    class Vocalist
    {
        public string Sort { get; set; }
    }

    class Drummer
    { }

    class OtherMusicians
    {
        public string Name { get; set; }
    }

    class MusicBand
    {

        public Vocalist Vocalist { get; set; }

        public Drummer Drummer { get; set; }

        public OtherMusicians OtherMusicians { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (Vocalist != null)
                sb.Append($"{Vocalist.Sort} \n");
            if (Drummer != null)
                sb.Append("Drummer \n");
            if (OtherMusicians != null)
                sb.Append($"Other musicians: {OtherMusicians.Name} \n");
            return sb.ToString();
        }
    }
}
