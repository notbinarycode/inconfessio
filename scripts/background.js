let P5;
let DotNet = null;

SetDotnetReference = function (pDotNetReference) {
    DotNet = pDotNetReference;
};

DisposeJs = function () {
    if (P5 != null) P5.remove();
}

window.setp5 = () => {
    let element =  window.document.getElementById('sketch-div');
    P5 = new p5(sketch, element);
};

let state = 0;
function SetState(val)
{
    state = val;
}

let sketch = function (p) {

    let pos = [0,0];
    let count = 0;
    let countMax = 5;
    let inverted = 0;
    let judgment = p.loadImage("images/judgment.jpg");
    
    p.setup = function () {
        p.createCanvas(window.innerWidth, window.innerHeight, p.WEBGL);
        p.frameRate(60);
        p.blendMode(p.ADD);
        pos = [judgment.width/3, judgment.height/3];
    }
    
    p.update = function()
    {
        if(state == 0)
        {
            pos[0] = p.noise(0.0025 * p.frameCount);
            pos[1] = p.noise((0.0025 * p.frameCount) + 10000);
        }
        else
        {
            pos[0] = p.noise(0.025 * p.frameCount);
            pos[1] = p.noise((0.025 * p.frameCount) + 10000);
        }
        pos[0] = p.map(pos[0], 0, 1, -judgment.width/4, judgment.width/4);
        pos[1] = p.map(pos[1], 0, 1, -judgment.height/3, judgment.height/3);
        if(count == 0)
        {
            countMax = p.floor(p.random(1,20));
            inverted = p.random(16);
        }
        count++;
        count%=countMax;
    }

    p.draw = function () {
        p.update();
        p.background(0);

        p.image(judgment, pos[0]-(judgment.width/2), pos[1]-(judgment.height/2));
        if(inverted < 1)
        {
            p.filter(p.INVERT);
        }
        if(state != 0)
        {
            p.filter(p.THRESHOLD, 0.6);
            p.image(judgment, pos[0]-(judgment.width/2), pos[1]-(judgment.height/2));
            p.filter(p.INVERT);
        }
    }
    
    p.windowResized = function () {
        p.resizeCanvas(p.windowWidth, p.windowHeight);
    }
};