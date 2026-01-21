using System.Collections.Generic;
public class FeatureCollection
{
    public List<Feature> Features { get; set; }
}


/// Represents a single earthquake entry

public class Feature
{
    public Properties Properties { get; set; }
}

/// Properties of an earthquake

public class Properties
{
    public string Place { get; set; }
    public double? Mag { get; set; }
}