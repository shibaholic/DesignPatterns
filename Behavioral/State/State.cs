namespace DesignPatterns.Behavioral.State;

public class Context
{
    public Presence Presence;
    public string? Message;

    public Context()
    {
        Presence = new Offline(this);
    }

    public void ChangeState(Presence newPresence)
    {
        Presence = newPresence;
    }

    public void BecomeOnline()
    {
        Presence.BecomeOnline();
    }
    public void BecomeOffline()
    {
        Presence.BecomeOffline();
    }
    public void BecomeIdle()
    {
        Presence.BecomeIdle();
    }
    public void BecomeBusy()
    {
        Presence.BecomeBusy();
    }
    public void ToggleDoNotDisturb()
    {
        Presence.ToggleDoNotDisturb();
    }
}

public abstract class Presence
{
    public Context Context;

    protected Presence(Context context)
    {
        Context = context;
    }

    public void SetContext(Context context)
    {
        Context = context;
    }

    public abstract void BecomeOnline();
    public abstract void BecomeOffline();
    public abstract void BecomeBusy();
    public abstract void BecomeIdle();
    public abstract void ToggleDoNotDisturb();
}
    
public class Offline(Context context) : Presence(context)
{
    public override void BecomeOnline()
    {
        Console.WriteLine("Offline -> Online");
        Context.ChangeState(new Online(Context));
    }
    
    public override void BecomeOffline() {}

    public override void BecomeBusy() { }

    public override void BecomeIdle() { }

    public override void ToggleDoNotDisturb() {}
}

public class Online(Context context) : Presence(context)
{
    public override void BecomeOnline() { }
    
    public override void BecomeOffline()
    {
        Console.WriteLine("Online -> Offline");
        Context.ChangeState(new Offline(Context));
    }
    
    public override void BecomeBusy()
    {
        Console.WriteLine("Online -> Busy");
        Context.ChangeState(new Busy(Context));
    }
    
    public override void BecomeIdle()
    {
        Console.WriteLine("Online -> Idle");
        Context.ChangeState(new Idle(Context));
    }

    public override void ToggleDoNotDisturb()
    {
        Console.WriteLine("Online -> DoNotDisturb");
        Context.ChangeState(new DoNotDisturb(Context));
    }
}

public class Busy(Context context) : Presence(context)
{
    public override void BecomeOnline()
    {
        Console.WriteLine("Busy -> Online");
        Context.ChangeState(new Online(Context));
    }

    public override void BecomeOffline()
    {
        Console.WriteLine("Busy -> Offline");
        Context.ChangeState(new Offline(Context));
    }
    
    public override void BecomeBusy() { }

    public override void BecomeIdle() { }

    public override void ToggleDoNotDisturb()
    {
        Console.WriteLine("Busy -> DoNotDisturb");
        Context.ChangeState(new DoNotDisturb(Context));
    }
}

public class Idle(Context context) : Presence(context)
{
    public override void BecomeOnline()
    {
        Console.WriteLine("Idle -> Online");
        Context.ChangeState(new Online(Context));
    }

    public override void BecomeOffline()
    {
        Console.WriteLine("Idle -> Offline");
        Context.ChangeState(new Offline(Context));
    }

    public override void BecomeBusy()
    {
        Console.WriteLine("Idle -> Busy");
        Context.ChangeState(new Busy(Context));
    }

    public override void BecomeIdle() { }

    public override void ToggleDoNotDisturb() { }
}

public class DoNotDisturb(Context context) : Presence(context)
{
    public override void BecomeOnline()
    {
        Console.WriteLine("DoNotDisturb -> Online");
        Context.ChangeState(new Online(Context));
    }

    public override void BecomeOffline()
    {
        Console.WriteLine("DoNotDisturb -> Offline");
        Context.ChangeState(new Offline(Context));
    }
    
    public override void BecomeBusy() { }

    public override void BecomeIdle() { }

    public override void ToggleDoNotDisturb()
    {
        Console.WriteLine("DoNotDisturb -> Online");
        Context.ChangeState(new Online(Context));
    }
}