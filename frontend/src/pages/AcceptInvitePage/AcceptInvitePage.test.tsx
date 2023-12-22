import { render, screen } from "@testing-library/react";

import React from "react";

import AcceptInvitePage from "./AcceptInvitePage";

describe("ViewGroupPage Componente", () => {
  test("renders ViewGroupPage correctly", () => {
    // Render
    render(<AcceptInvitePage />);

    // Assert
    expect(screen.getByTestId("page-title")).toBeInTheDocument();
    expect(screen.getByTestId("page-description")).toBeInTheDocument();
  });
});
