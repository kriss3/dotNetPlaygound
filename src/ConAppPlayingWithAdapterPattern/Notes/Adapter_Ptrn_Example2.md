```mermaid
classDiagram
Client --> Target : calls
Adapter ..|> Target : implements
Adapter o--> Adaptee : wraps
class Client
class Target{
	<<interface>>
	+request()
}
class Adaptee{
	+specificRequest()
}
class Adapter{
	-Adaptee adaptee
	+request()
}