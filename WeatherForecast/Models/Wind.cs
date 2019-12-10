namespace WeatherForecast.Models
{
    public class Wind
    {
        public float Speed { get; set; }
        public int Deg { get; set; }
        public string Dir { get; set; }

        public void GetDir()
        {
            if (Deg >= 22.5 && Deg < 67.5)
            {
                Dir = "NE";
            }

            else
            {
                if (Deg >= 67.5 && Deg < 112.5)
                {
                    Dir = "E";
                }

                else
                {
                    if (Deg >= 112.5 && Deg < 157.5)
                    {
                        Dir = "SE";
                    }
                    else
                    {
                        if (Deg >= 157.5 && Deg < 202.5)
                        {
                            Dir = "S";
                        }
                        else
                        {
                            if (Deg >= 202.5 && Deg < 247.5)
                            {
                                Dir = "SW";
                            }
                            else
                            {
                                if (Deg >= 247.5 && Deg < 292.5)
                                {
                                    Dir = "W";
                                }
                                else
                                {
                                    if (Deg >= 292.5 && Deg < 337.5)
                                    {
                                        Dir = "NW";
                                    }
                                    else
                                    {
                                        Dir = "W";
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}