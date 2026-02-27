using MoreMountains.CorgiEngine;
using UnityEngine;

public class TeleportHealth : Health
{
    public float TeleportDamageTaken = 3;
    public float TeleportFlickerDuration = .6f;
    public float TeleportInvincibilityDuration = .3f;
    private TeleportPoint _teleportPoint;

    private void Update()
    {
        if (!_controller.State.IsGrounded || TeleportPoint.TeleportPoints.Count == 0) return;
        _teleportPoint = TeleportPoint.TeleportPoints[0];
        foreach (var teleportPoint in TeleportPoint.TeleportPoints)
            if (DistanceTo(teleportPoint) < DistanceTo(_teleportPoint))
                _teleportPoint = teleportPoint;
        float DistanceTo(TeleportPoint p) => Vector2.Distance(p.Position, transform.position);
    }
    public override void Kill()
    {
        if (CurrentHealth > TeleportDamageTaken && CurrentHealth > 0)
        {
            var position = _teleportPoint.Position;
            position.y += _controller.Height() / 2;
            _controller.SetTransformPosition(position);
            if (TeleportDamageTaken > 0) Damage(TeleportDamageTaken, gameObject, TeleportFlickerDuration, TeleportInvincibilityDuration, Vector3.zero);
        }
        else base.Kill();
    }
}
