namespace DesignPatterns.Creational.Prototype;

public abstract class Prototype {
    public readonly string id;

    public Prototype(string id) {
        this.id = id;
    }

    public abstract Prototype Clone();
}

public class Rule : Prototype {
    // rule logic implementation

    public string logic { get; set; }

    public Rule(string id, string logic):base(id) {
        this.logic = logic;
    }

    public override Rule Clone() {
        return (Rule) this.MemberwiseClone();
    }
}

public class PurchaseLogic : Prototype {
    public List<Rule> rules;

    public PurchaseLogic(string id, List<Rule> rules):base(id) {
        this.rules = rules;
        if (!validate()) { // validate is computationally expensive
            throw new Exception("Invalid PurchaseLogic rules.");
        }
    }

    public bool validate() {
        // imagine that this is a computationally expensive operation.
        return true;
    }

    public override PurchaseLogic Clone() {
        PurchaseLogic clone = (PurchaseLogic) this.MemberwiseClone();
        clone.rules = rules.Select(rule => (Rule)rule.Clone()).ToList();
        return clone;
    }
}

public class AmazonPurchaseLogic : PurchaseLogic {
    private String? specific_amazon_config;

    public AmazonPurchaseLogic(string id, List<Rule> rules):base(id, rules) {
    }

    public override AmazonPurchaseLogic Clone() {
        AmazonPurchaseLogic clone = (AmazonPurchaseLogic) this.MemberwiseClone();
        clone.rules = rules.Select(rule => (Rule)rule.Clone()).ToList();
        return clone;
    }
}