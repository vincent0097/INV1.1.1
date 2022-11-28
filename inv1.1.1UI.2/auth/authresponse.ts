export class AuthResponse{
    username!: string;
    Firstname!: string;
    Lastname!: string;
    Email!: string;
    Password!: string;
    result!: {
        result: boolean;
        message: string;
    };
}