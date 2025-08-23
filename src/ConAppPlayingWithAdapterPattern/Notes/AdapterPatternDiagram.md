```mermaid
flowchart
  C[CheckoutService]
  A[LegacyGatewayAdapter]
  G[LegacyGateway]

  %% Flow (labels quoted)
  C -- "PayOrder(card, total)" --> A
  A -- "Charge(card, amount)" --> G
  G -- "MakePayment(amount, card)" --> A
  A -- "map OK → true; ERR → false" --> C