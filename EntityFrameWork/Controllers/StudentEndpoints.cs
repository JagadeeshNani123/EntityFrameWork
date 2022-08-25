using Microsoft.EntityFrameworkCore;
using EntityFrameWork.Data;
using EntityFrameWork.Models;
namespace EntityFrameWork.Controllers;

public static class StudentEndpoints
{
    public static void MapStudentEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Student", async (EntityFrameWorkContext db) =>
        {
            return await db.Student.ToListAsync();
        })
        .WithName("GetAllStudents");

        routes.MapGet("/api/Student/{id}", async (int RoleNumber, EntityFrameWorkContext db) =>
        {
            return await db.Student.FindAsync(RoleNumber)
                is Student model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetStudentById");

        routes.MapPut("/api/Student/{id}", async (int RoleNumber, Student student, EntityFrameWorkContext db) =>
        {
            var foundModel = await db.Student.FindAsync(RoleNumber);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            //update model properties here

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateStudent");

        routes.MapPost("/api/Student/", async (Student student, EntityFrameWorkContext db) =>
        {
            db.Student.Add(student);
            await db.SaveChangesAsync();
            return Results.Created($"/Students/{student.RoleNumber}", student);
        })
        .WithName("CreateStudent");

        routes.MapDelete("/api/Student/{id}", async (int RoleNumber, EntityFrameWorkContext db) =>
        {
            if (await db.Student.FindAsync(RoleNumber) is Student student)
            {
                db.Student.Remove(student);
                await db.SaveChangesAsync();
                return Results.Ok(student);
            }

            return Results.NotFound();
        })
        .WithName("DeleteStudent");
    }
}
