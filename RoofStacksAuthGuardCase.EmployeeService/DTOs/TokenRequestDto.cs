﻿namespace RoofStacksAuthGuardCase.EmployeeService.DTOs
{
    public class TokenRequestDto
    {
        public string? AccessToken { get; set; }
        public int ExpiresIn { get; set; }
        public string? TokenType { get; set; }
        public string? Scope { get; set; }
    }
}
