﻿namespace DevFreela.Application.InputModels.Comment;

public class CreateCommentInputModel
{
    public string Content { get; set; }
    public int IdProject { get; set; }
    public int IdUser { get; set; }
}