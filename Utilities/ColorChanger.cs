using UnityEngine;

namespace Oxygen.Utilities
{
    public class TimedBehaviour : MonoBehaviour
    {
        public virtual void Start()
        {
            this.startTime = Time.time;
        }
        public virtual void Update()
        {
            if (!this.complete)
            {
                this.progress = Mathf.Clamp((Time.time - this.startTime) / this.duration, 0f, 1f);
                if (Time.time - this.startTime > this.duration)
                {
                    if (this.loop)
                    {
                        this.OnLoop();
                    }
                    else
                    {
                        this.complete = true;
                    }
                }
            }
        }
        public virtual void OnLoop()
        {
            this.startTime = Time.time;
        }
        public bool complete = false;
        public bool loop = true;
        public float progress = 0f;
        protected bool paused = false;
        protected float startTime;
        protected float duration = 2f;
    }
    public class ColorChanger : TimedBehaviour
    {
        public override void Start()
        {
            base.Start();
            if (base.GetComponent<Renderer>() != null)
            {
                this.gameObjectRenderer = base.GetComponent<Renderer>();
            }
        }
        public override void Update()
        {
            base.Update();
            if (this.colors != null)
            {
                if (this.timeBased)
                {
                    this.color = this.colors.Evaluate(this.progress);
                }
                this.gameObjectRenderer.material.color = this.color;
                this.gameObjectRenderer.material.SetColor("_EmissionColor", this.color);
            }
        }
        public Renderer gameObjectRenderer;
        public Gradient colors = null;
        public Color color;
        public bool timeBased = true;
    }
}