﻿// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2007:Consider calling ConfigureAwait on the awaited task", Justification = "<Pending>", Scope = "member", Target = "~M:PeTelecom.Modules.UserAccess.Application.Authentication.Authenticate.AuthenticateCommandHandler.Handle(PeTelecom.Modules.UserAccess.Application.Authentication.Authenticate.AuthenticateCommand,System.Threading.CancellationToken)~System.Threading.Tasks.Task{PeTelecom.Modules.UserAccess.Application.Authentication.Authenticate.AuthenticationResult}")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2007:Consider calling ConfigureAwait on the awaited task", Justification = "<Pending>", Scope = "member", Target = "~M:PeTelecom.Modules.UserAccess.Application.Authorization.GetUserPermissions.GetUserPermissionsQueryHandler.Handle(PeTelecom.Modules.UserAccess.Application.Authorization.GetUserPermissions.GetUserPermissionQuery,System.Threading.CancellationToken)~System.Threading.Tasks.Task{System.Collections.Generic.List{PeTelecom.Modules.UserAccess.Application.Authorization.GetUserPermissions.UserPermissionDto}}")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2007:Consider calling ConfigureAwait on the awaited task", Justification = "<Pending>", Scope = "member", Target = "~M:PeTelecom.Modules.UserAccess.Application.UserRegistrations.ConfirmUserRegistration.ConfirmUserRegistrationCommandHandler.Handle(PeTelecom.Modules.UserAccess.Application.UserRegistrations.ConfirmUserRegistration.ConfirmUserRegistrationCommand,System.Threading.CancellationToken)~System.Threading.Tasks.Task{MediatR.Unit}")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2007:Consider calling ConfigureAwait on the awaited task", Justification = "<Pending>", Scope = "member", Target = "~M:PeTelecom.Modules.UserAccess.Application.UserRegistrations.RegisterNewUser.NewUserRegisteredEnqueueEmailConfirmationHandler.Handle(PeTelecom.Modules.UserAccess.Application.UserRegistrations.RegisterNewUser.NewUserRegisteredNotification,System.Threading.CancellationToken)~System.Threading.Tasks.Task")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2007:Consider calling ConfigureAwait on the awaited task", Justification = "<Pending>", Scope = "member", Target = "~M:PeTelecom.Modules.UserAccess.Application.UserRegistrations.RegisterNewUser.RegisterNewUserCommandHandler.Handle(PeTelecom.Modules.UserAccess.Application.UserRegistrations.RegisterNewUser.RegisterNewUserCommand,System.Threading.CancellationToken)~System.Threading.Tasks.Task{MediatR.Unit}")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2007:Consider calling ConfigureAwait on the awaited task", Justification = "<Pending>", Scope = "member", Target = "~M:PeTelecom.Modules.UserAccess.Application.UserRegistrations.SendUserRegistrationConfirmationEmail.SendUserRegistrationConfirmationEmailCommandHandler.Handle(PeTelecom.Modules.UserAccess.Application.UserRegistrations.SendUserRegistrationConfirmationEmail.SendUserRegistrationConfirmationEmailCommand,System.Threading.CancellationToken)~System.Threading.Tasks.Task{MediatR.Unit}")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2007:Consider calling ConfigureAwait on the awaited task", Justification = "<Pending>", Scope = "member", Target = "~M:PeTelecom.Modules.UserAccess.Application.Users.CreateUser.CreateUserCommandHandler.Handle(PeTelecom.Modules.UserAccess.Application.Users.CreateUser.CreateUserCommand,System.Threading.CancellationToken)~System.Threading.Tasks.Task{MediatR.Unit}")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2007:Consider calling ConfigureAwait on the awaited task", Justification = "<Pending>", Scope = "member", Target = "~M:PeTelecom.Modules.UserAccess.Application.Users.CreateUser.UserRegistrationConfirmedNotificationHandler.Handle(PeTelecom.Modules.UserAccess.Application.Users.CreateUser.UserRegistrationConfirmedNotification,System.Threading.CancellationToken)~System.Threading.Tasks.Task")]

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "<Pending>", Scope = "member", Target = "~P:PeTelecom.Modules.UserAccess.Application.Authentication.Authenticate.UserDto.Claims")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1812:Avoid uninstantiated internal classes", Justification = "<Pending>", Scope = "type", Target = "~T:PeTelecom.Modules.UserAccess.Application.UserRegistrations.SendUserRegistrationConfirmationEmail.SendUserRegistrationConfirmationEmailCommandHandler")]
