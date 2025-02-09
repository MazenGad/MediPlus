namespace MediPlus.Helpers
{
    public static class ServiceHelper
    {
        public static string GetServiceIcon(string serviceName)
        {
            return serviceName switch
            {
                "General Treatment" => "icofont-prescription",
                "Teeth Whitening" => "icofont-tooth",
                "Heart Surgery" => "icofont-heart-beat",
				"Hearing Assessment" => "icofont-listening",
				"Laser Eye Surgery" => "icofont-eye-alt",
				"Blood Clotting Test" => "icofont-blood",
                _ => "icofont-ui-health"
            };
        }
    }
}
