#pragma once
class Scene
{
public:
	Scene();
	virtual ~Scene();

	virtual void Start() abstract;
	virtual void Update() abstract;
	virtual void Render(HDC hdc) abstract;
};

