#include "framework.h"
#include "Vector2.h"

Vector2::Vector2()
{
}

Vector2::Vector2(float x, float y)
: _x(x)
, _y(y)
{
}

Vector2::~Vector2()
{
}

Vector2 Vector2::operator+(const Vector2& value)
{
    Vector2 result;
    result._x = _x + value._x;
    result._y = _y + value._y;

    return result;
}

Vector2 Vector2::operator-(const Vector2& value)
{
    Vector2 result;
    result._x = _x - value._x;
    result._y = _y - value._y;

    return result;
}

Vector2& Vector2::operator+=(const Vector2& value)
{
    _x += value._x;
    _y += value._y;

    return *this;
}

Vector2& Vector2::operator-=(const Vector2& value)
{
    _x -= value._x;
    _y -= value._y;

    return *this;
}

Vector2 Vector2::operator*(const float& value)
{
    Vector2 result;
    result._x = this->_x * value;
    result._y = this->_y * value;

    return result;
}

Vector2& Vector2::operator=(const Vector2& value)
{
    _x = value._x;
    _y = value._y;

    return *this;
}
