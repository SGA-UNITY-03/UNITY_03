#pragma once
class PaintScene : public Scene
{
public:
	PaintScene();
	virtual ~PaintScene();

	// Scene을(를) 통해 상속됨
	virtual void Start() override;
	virtual void Update() override;
	virtual void Render(HDC hdc) override;

private:
	HBRUSH _brush;
	HPEN _pen;
};

